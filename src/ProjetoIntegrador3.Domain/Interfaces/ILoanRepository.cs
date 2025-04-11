using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Domain.Interfaces;

public interface ILoanRepository : IDisposable
{
    Task<IEnumerable<Loan>> GetAllLoans();
    Task<Loan> GetLoanById(int id);
}