using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Domain.Interfaces;

public interface IGenreRepository : IDisposable
{
    Task<Genre> GetById(int id);
    Task<IEnumerable<Genre>> GetAll();
    void CreateGenre(Genre genre);
    void UpdateGenre(Genre genre);
    void DeleteGenre(Genre genre);
}