using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador3.Domain.Interfaces;
using ProjetoIntegrador3.Domain.Models;
using ProjetoIntegrador3.Domain.Models.Enums;
using ProjetoIntegrador3.Infra.Data.Context;

namespace ProjetoIntegrador3.Infra.Data.Repository;

public class BookRepository : IBookRepository
{
    protected readonly PiApplicationDbContext Db;
    protected readonly DbSet<Book> DbSet;

    public BookRepository(PiApplicationDbContext dbContext)
    {
        Db = dbContext;
        DbSet = Db.Set<Book>();
    }

    public async Task<Book> GetById(int id)
    {
        return await DbSet.Include(b => b.Genre).FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<IEnumerable<Book>> GetAll(string? title, int? genreId)
    {
        return await DbSet.Include(b => b.Genre)
            .Where(b => genreId != null ? b.Genre.Id == genreId : true)
            .Where(b => title != null ? b.Title.Contains(title): true)
            .OrderBy(b => b.Title)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Book>> GetAllByGenre(int genreId)
    {
        return await DbSet.Include(b => b.Genre).Where(b => b.Genre.Id == genreId).ToListAsync(); 
    }

    public void UpdateStatus(Book book, BookStatus status)
    {
        book.Status = status;
        Update(book);
    }

    public void Create(Book book)
    {
        DbSet.Add(book);
        Db.SaveChanges();
    }

    public void Update(Book book)
    {
        DbSet.Update(book);
        Db.SaveChanges();
    }

    public void Delete(Book book)
    {
        DbSet.Remove(book);
        Db.SaveChanges();
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}