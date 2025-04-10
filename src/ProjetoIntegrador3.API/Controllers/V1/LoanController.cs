using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador3.Application.Exceptions;
using ProjetoIntegrador3.Application.Interfaces;
using ProjetoIntegrador3.Application.ViewModels;
using ProjetoIntegrador3.Domain.Interfaces;

namespace ProjetoIntegrador3.API.Controllers.V1;

[ApiVersion("1.0")]
[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/loans")]
public class LoanController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoanController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet("{id:int:required}/user/{userId:guid:required}")]
    public async Task<ActionResult<LoanViewModel>> GetByIdAndUserId(int id, Guid userId)
    {
        try
        {
            return await _loanService.GetLoanByIdAndUserIdAsync(id, userId);
        }
        catch (UserNotFoundException e)
        {
            return NotFound(new CustomErrorResponseViewModel
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (LoanNotFoundException e)
        {
            return NotFound(new CustomErrorResponseViewModel
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, new CustomErrorResponseViewModel
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
    }
    
    [HttpGet("/user/{userId:guid:required}")]
    public async Task<ActionResult<IEnumerable<LoanViewModel>>> GetAllByUserId(Guid userId)
    {
        try
        {
            return Ok(new
            {
                data = await _loanService.GetLoansByUserAsync(userId)
            });
        }
        catch (UserNotFoundException e)
        {
            return NotFound(new CustomErrorResponseViewModel
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, new CustomErrorResponseViewModel
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = e.Message,
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
    }
}