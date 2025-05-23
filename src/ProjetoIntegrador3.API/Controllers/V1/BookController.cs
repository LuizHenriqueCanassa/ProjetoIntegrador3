using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador3.Application.Exceptions;
using ProjetoIntegrador3.Application.Interfaces;
using ProjetoIntegrador3.Application.ViewModels;
using ProjetoIntegrador3.Infra.Identity.Authorization;

namespace ProjetoIntegrador3.API.Controllers.V1;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/books")]
[Authorize]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<BookViewModel>>> GetAll([FromQuery] SearchBookParamsViewModel searchParams)
    {
        return Ok(await _bookService.GetAll(searchParams));
    }
    
    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<ActionResult<BookViewModel>> GetById(int id)
    {
        try
        {
            return Ok(await _bookService.GetById(id));
        }
        catch (RegisterNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("genre/{genreId:int}")]
    [AllowAnonymous]
    public async Task<ActionResult<BookViewModel>> GetAllByGenre(int genreId)
    {
        try
        {
            return Ok(new
            {
                Data = await _bookService.GetAllByGenre(genreId)
            });
        }
        catch (RegisterNotFoundException e)
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
                Message = "Houve um erro desconhecido!",
                Uri = HttpContext.Request.Path.Value,
                DateOcurrence = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            });
        }
    }

    [HttpPost]
    [CustomAuthorize("Book", "Create")]
    public IActionResult Create([FromBody] CreateUpdateBookViewModel viewModel)
    {
        try
        {
            _bookService.Create(viewModel);

            return Created();
        }
        catch (RegisterNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut("{id:int}")]
    [CustomAuthorize("Book", "Update")]
    public IActionResult Update(int id, [FromBody] CreateUpdateBookViewModel viewModel)
    {
        try
        {
            _bookService.Update(id, viewModel);
            
            return NoContent();
        }
        catch (RegisterNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    [CustomAuthorize("Book", "Delete")]
    public IActionResult Delete(int id)
    {
        try
        {
            _bookService.Delete(id);
            
            return NoContent();
        }
        catch (RegisterNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}