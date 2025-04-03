using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador3.Domain.Interfaces;
using ProjetoIntegrador3.Domain.Models;
using ProjetoIntegrador3.Infra.Data.Context;

namespace ProjetoIntegrador3.Infra.Data.Repository;

public class GenreRepository : IGenreRepository
{
    protected readonly PiApplicationDbContext Db;
    protected readonly DbSet<Genre> DbSet;

    public GenreRepository(PiApplicationDbContext dbContext)
    {
        Db = dbContext;
        DbSet = Db.Set<Genre>();
    }

    public async Task<Genre> GetById(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<IEnumerable<Genre>> GetAll()
    {
        return await DbSet.OrderBy(x => x.Name).ToListAsync();
    }

    public void CreateGenre(Genre genre)
    {
        DbSet.Add(genre);
        Db.SaveChanges();
    }

    public void UpdateGenre(Genre genre)
    {
        DbSet.Update(genre);
        Db.SaveChanges();
    }

    public void DeleteGenre(Genre genre)
    {
        DbSet.Remove(genre);
        Db.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Db.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}