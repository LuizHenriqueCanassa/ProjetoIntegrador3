using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador3.Application.Exceptions;
using ProjetoIntegrador3.Application.Interfaces;
using ProjetoIntegrador3.Application.ViewModels;
using ProjetoIntegrador3.Domain.Models;
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
    
}