using ProjetoIntegrador3.Domain.Models;
using ProjetoIntegrador3.Domain.Models.Enums;

namespace ProjetoIntegrador3.Domain.Interfaces;

public interface IBookRepository : IDisposable
{
    Task<Book> GetById(int id);
    Task<IEnumerable<Book>> GetAll();
    Task<IEnumerable<Book>> GetAllByGenre(int genreId);
    void UpdateStatus(Book book, BookStatus status);
    void Create(Book book);
    void Update(Book book);
    void Delete(Book book);
}