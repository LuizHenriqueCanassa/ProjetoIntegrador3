using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador3.Application.Exceptions;
using ProjetoIntegrador3.Application.Interfaces;
using ProjetoIntegrador3.Application.ViewModels;

namespace ProjetoIntegrador3.API.Controllers.V1;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookViewModel>>> GetAll()
    {
        return Ok(await _bookService.GetAll());
    }
    
    [HttpGet("{id:int}")]
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