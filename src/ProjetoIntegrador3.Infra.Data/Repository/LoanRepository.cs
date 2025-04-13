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

    public async Task<IEnumerable<Loan>> GetAllLoans()
    {
        return await DbSet
            .Include(l => l.User)
            .Include(l => l.Book)
            .Include(l => l.Book.Genre)
            .ToListAsync();
    }

    public async Task<Loan> GetLoanById(int id)
    {
        return await DbSet
            .Include(l => l.User)
            .Include(l => l.Book)
            .Include(l => l.Book.Genre)
            .Where(l => l.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Loan>> GetLoansByUserId(Guid id)
    {
        return await DbSet
            .Include(l => l.User)
            .Include(l => l.Book)
            .Include(l => l.Book.Genre)
            .Where(l => l.User.Id == id.ToString())
            .ToListAsync();
    }

    public async Task<IEnumerable<Loan>> GetLoansByBook(Book book)
    {
        return await DbSet
            .Include(l => l.User)
            .Include(l => l.Book)
            .Include(l => l.Book.Genre)
            .Where(l => l.Book == book)
            .ToListAsync();
    }

    public void AddRequestLoan(Book book, ApplicationUser user)
    {
        Db.AddAsync(new Loan
        {
            Book = book, 
            User = user,
            LoanDate = DateTime.Now.ToUniversalTime(),
            ReturnDate = DateTime.Now.ToUniversalTime().AddDays(7)
        });
        Db.SaveChanges();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}