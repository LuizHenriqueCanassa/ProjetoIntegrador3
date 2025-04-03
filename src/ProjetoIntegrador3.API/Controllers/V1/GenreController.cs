using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador3.Application.Exceptions;
using ProjetoIntegrador3.Application.Interfaces;
using ProjetoIntegrador3.Application.ViewModels;

namespace ProjetoIntegrador3.API.Controllers.V1;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/genres")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<IEnumerable<GenreViewModel>> GetAll()
    {
        return await _genreService.GetAll();
    }

    [HttpGet("{id:int}")]
    public async Task<GenreViewModel> GetById(int id)
    {
        return await _genreService.GetById(id);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGenre([FromBody] CreateUpdateGenreViewModel viewModel)
    {
        _genreService.CreateGenre(viewModel);

        return Created();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateGenre(int id, [FromBody] CreateUpdateGenreViewModel viewModel)
    {
        try
        {
            _genreService.UpdateGenre(id, viewModel);

            return NoContent();
        }
        catch (RegisterNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteGenre(int id)
    {
        try
        {
            _genreService.DeleteGenre(id);
            
            return NoContent();
        }
        catch (RegisterNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}