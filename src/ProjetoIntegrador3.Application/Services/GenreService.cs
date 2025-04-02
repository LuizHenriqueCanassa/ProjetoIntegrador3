using ProjetoIntegrador3.Application.Interfaces;
using ProjetoIntegrador3.Application.ViewModels;
using ProjetoIntegrador3.Domain.Interfaces;

namespace ProjetoIntegrador3.Application.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public Task<IEnumerable<GenreViewModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<GenreViewModel> GetById(int id)
    {
        throw new NotImplementedException();
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}