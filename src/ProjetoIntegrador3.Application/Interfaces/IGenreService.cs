using ProjetoIntegrador3.Application.ViewModels;

namespace ProjetoIntegrador3.Application.Interfaces;

public interface IGenreService : IDisposable
{
    Task<IEnumerable<GenreViewModel>> GetAll();
    Task<GenreViewModel> GetById(int id);
    void Create(CreateUpdateGenreViewModel viewModel);
    void Update(int id, CreateUpdateGenreViewModel viewModel);
    void Delete(int id);
}