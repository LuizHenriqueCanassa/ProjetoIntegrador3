using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Domain.Interfaces;

public interface ILoanRepository : IDisposable
{
    Task<Loan> GetByIdAndUser(int id, ApplicationUser user);
    Task<List<Loan>> GetAllByUser(ApplicationUser user);
}