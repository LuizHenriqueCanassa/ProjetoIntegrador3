using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador3.Domain.Interfaces;
using ProjetoIntegrador3.Domain.Models;
using ProjetoIntegrador3.Infra.Data.Context;

namespace ProjetoIntegrador3.Infra.Data.Repository;

public class LoanRepository : ILoanRepository
{
    protected readonly PiApplicationDbContext Db;
    protected readonly DbSet<Loan> DbSet;

    public LoanRepository(PiApplicationDbContext dbContext)
    {
        Db = dbContext;
        DbSet = Db.Set<Loan>();
    }

    public async Task<Loan> GetByIdAndUser(int id, ApplicationUser user)
    {
        return await DbSet
            .Include(l => l.User)
            .Include(l => l.Book)
            .Where(l => l.Id == id && l.User == user)
            .SingleOrDefaultAsync();
    }

    public async Task<List<Loan>> GetAllByUser(ApplicationUser user)
    {
        return await DbSet
            .Include(l => l.User)
            .Include(l => l.Book)
            .Where(l => l.User == user)
            .ToListAsync();
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}