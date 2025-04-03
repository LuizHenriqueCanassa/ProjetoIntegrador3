using ProjetoIntegrador3.Application.ViewModels;

namespace ProjetoIntegrador3.Application.Interfaces;

public interface IGenreService : IDisposable
{
    Task<IEnumerable<GenreViewModel>> GetAll();
    Task<GenreViewModel> GetById(int id);
    void CreateGenre(CreateUpdateGenreViewModel viewModel);
    void UpdateGenre(int id, CreateUpdateGenreViewModel viewModel);
    void DeleteGenre(int id);
}