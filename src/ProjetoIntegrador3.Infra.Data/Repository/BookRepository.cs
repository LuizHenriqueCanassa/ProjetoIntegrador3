using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador3.Domain.Interfaces;
using ProjetoIntegrador3.Domain.Models;
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

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await DbSet.Include(b => b.Genre).ToListAsync();
    }
    
    public async Task<IEnumerable<Book>> GetAllByGenre(int genreId)
    {
        return await DbSet.Include(b => b.Genre).Where(b => b.Genre.Id == genreId).ToListAsync(); 
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