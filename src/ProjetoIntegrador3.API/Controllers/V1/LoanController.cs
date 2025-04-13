using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador3.Application.Exceptions;
using ProjetoIntegrador3.Application.Interfaces;
using ProjetoIntegrador3.Application.Utils;
using ProjetoIntegrador3.Application.ViewModels;
using ProjetoIntegrador3.Domain.Models;
using ProjetoIntegrador3.Domain.Models.Enums;
using ProjetoIntegrador3.Infra.Identity.Authorization;

namespace ProjetoIntegrador3.API.Controllers.V1;

[ApiVersion("1.0")]
[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/loans")]
public class LoanController : ControllerBase
{
    private readonly ILoanService _loanService;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoanController(ILoanService loanService, UserManager<ApplicationUser> userManager)
    {
        _loanService = loanService;
        _userManager = userManager;
    }

    [HttpGet]
    [CustomAuthorize("Loan", "ReadAll")]
    public async Task<ActionResult<IEnumerable<LoanViewModel>>> GetAllLoans()
    {
        return Ok(new
        {
            data = await _loanService.GetAllLoans()
        });
    }

    [HttpGet("{id}")]
    [CustomAuthorize("Loan", "Read")]
    public async Task<ActionResult<LoanViewModel>> GetLoan(int id)
    {
        try
        {
            var userLogged = await _userManager.FindByNameAsync(User.Identity.Name);
            
            var loanViewModel = await _loanService.GetLoanById(id);
            
            if (User.IsInRole("User"))
                if (userLogged != null && userLogged.Id != loanViewModel.User.Id) return StatusCode(StatusCodes.Status403Forbidden);
            
            return Ok(loanViewModel);
        }
        catch (LoanNotFoundException e)
        {
            return NotFound(new CustomErrorResponseViewModel
            {
                StatusCode = 404,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, new CustomErrorResponseViewModel
            {
                StatusCode = 500,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
    }

    [HttpGet("user/{userId:guid}")]
    [CustomAuthorize("Loan", "Read")]
    public async Task<ActionResult<IEnumerable<LoanViewModel>>> GetLoansByUser(Guid userId)
    {
        try
        {
            if (await _userManager.FindByIdAsync(userId.ToString()) == null)
                throw new UserNotFoundException("Nenhum usuario encontrado");

            var userLogged = await _userManager.FindByNameAsync(User.Identity.Name);

            var loanViewModel = await _loanService.GetLoansByUserId(userId);

            if (User.IsInRole("User"))
                if (userLogged != null && userLogged.Id != userId.ToString())
                    return StatusCode(StatusCodes.Status403Forbidden);

            return Ok(loanViewModel);
        }
        catch (UserNotFoundException e)
        {
            return NotFound(new CustomErrorResponseViewModel
            {
                StatusCode = 404,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, new CustomErrorResponseViewModel
            {
                StatusCode = 500,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
    }

    [HttpPost("request")]
    [CustomAuthorize("Loan", "Create")]
    public async Task<IActionResult> RequestLoan([FromQuery] int bookId, [FromQuery] Guid userId)
    {
        try
        {
            var userLogged = await _userManager.FindByNameAsync(User.Identity.Name);

            if (User.IsInRole("User"))
                if (userLogged != null && userLogged.Id != userId.ToString())
                    return StatusCode(StatusCodes.Status403Forbidden);

            await _loanService.AddRequestLoan(bookId, userId);

            return Created();
        }
        catch (BookInUseException e)
        {
            return NotFound(new CustomErrorResponseViewModel
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (RegisterNotFoundException e)
        {
            return NotFound(new CustomErrorResponseViewModel
            {
                StatusCode = 404,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (UserNotFoundException e)
        {
            return NotFound(new CustomErrorResponseViewModel
            {
                StatusCode = 404,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, new CustomErrorResponseViewModel
            {
                StatusCode = 500,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
    }

    /// <summary>
    /// Altera o status de um aluguel
    /// </summary>
    /// <param name="loanId">Id do  Aluguel</param>
    /// <param name="loanStatus">Espera os seguintes parametros de status: ALUGUEL_VIGENTE, DEVOLVIDO </param>
    /// <response code="204">Aluguel alterado com sucesso</response>
    /// <response code="404">Aluguel nao contrado</response>
    /// <response code="400">Status invalido</response>
    /// <response code="500">Erro Desconhecido</response>
    [HttpPut("{loanId:int}/status")]
    [CustomAuthorize("Loan", "Update")]
    public async Task<IActionResult> UpdateLoanStatus(int loanId, [FromQuery] string loanStatus)
    {
        try
        {
            var status = EnumUtils.GetValueFromDescription<LoanStatus>(loanStatus);
            
            await _loanService.UpdateLoanStatus(loanId, status);
            
            return NoContent();
        }
        catch (LoanNotFoundException e)
        {
            return NotFound(new CustomErrorResponseViewModel
            {
                StatusCode = 404,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (LoanStatusException e)
        {
            return NotFound(new CustomErrorResponseViewModel
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (ArgumentException e)
        {
            return NotFound(new CustomErrorResponseViewModel
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, new CustomErrorResponseViewModel
            {
                StatusCode = 500,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
    }

    [HttpPut("{loanId:int}/cancel")]
    [CustomAuthorize("Loan", "Update")]
    public async Task<IActionResult> CancelLoan(int loanId)
    {
        try
        {
            await _loanService.CancelLoan(loanId);

            return NoContent();
        }
        catch (LoanNotFoundException e)
        {
            return NotFound(new CustomErrorResponseViewModel
            {
                StatusCode = 404,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (LoanStatusException e)
        {
            return NotFound(new CustomErrorResponseViewModel
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, new CustomErrorResponseViewModel
            {
                StatusCode = 500,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
    }
}