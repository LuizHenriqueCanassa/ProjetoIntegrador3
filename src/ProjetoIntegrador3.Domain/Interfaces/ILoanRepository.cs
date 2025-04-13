using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Domain.Interfaces;

public interface ILoanRepository : IDisposable
{
    Task<IEnumerable<Loan>> GetAllLoans();
    Task<Loan> GetLoanById(int id);
    Task<IEnumerable<Loan>> GetLoansByUserId(Guid id);
    Task<IEnumerable<Loan>> GetLoansByBook(Book book);
    void AddRequestLoan(Book book, ApplicationUser applicationUser);
    void CancelLoan(Loan loan);
}