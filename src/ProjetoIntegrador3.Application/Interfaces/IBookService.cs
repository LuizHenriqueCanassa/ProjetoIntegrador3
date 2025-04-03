using ProjetoIntegrador3.Application.ViewModels;

namespace ProjetoIntegrador3.Application.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookViewModel>> GetAll();
    Task<BookViewModel> GetById(int id);
    void Create(CreateUpdateBookViewModel viewModel);
    void Update(int id, CreateUpdateBookViewModel viewModel);
    void Delete(int id);
}