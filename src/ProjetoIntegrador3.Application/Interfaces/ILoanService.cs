using ProjetoIntegrador3.Application.ViewModels;

namespace ProjetoIntegrador3.Application.Interfaces;

public interface ILoanService
{
    Task<IEnumerable<LoanViewModel>> GetAllLoans();
    Task<LoanViewModel> GetLoanById(int id);
    Task<IEnumerable<LoanViewModel>> GetLoansByUserId(Guid id);
}