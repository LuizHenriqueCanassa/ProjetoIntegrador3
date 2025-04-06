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
[Route("api/v{version:apiVersion}/genres")]
[Authorize]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IEnumerable<GenreViewModel>> GetAll()
    {
        return await _genreService.GetAll();
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<GenreViewModel> GetById(int id)
    {
        return await _genreService.GetById(id);
    }

    [HttpPost]
    [CustomAuthorize("Genre", "Create")]
    public async Task<IActionResult> CreateGenre([FromBody] CreateUpdateGenreViewModel viewModel)
    {
        _genreService.Create(viewModel);

        return Created();
    }

    [HttpPut("{id:int}")]
    [CustomAuthorize("Genre", "Update")]
    public IActionResult UpdateGenre(int id, [FromBody] CreateUpdateGenreViewModel viewModel)
    {
        try
        {
            _genreService.Update(id, viewModel);

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
    [CustomAuthorize("Genre", "Delete")]
    public IActionResult DeleteGenre(int id)
    {
        try
        {
            _genreService.Delete(id);
            
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