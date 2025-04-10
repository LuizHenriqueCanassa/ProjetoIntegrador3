using ProjetoIntegrador3.Application.ViewModels;

namespace ProjetoIntegrador3.Application.Interfaces;

public interface ILoanService
{
    Task<IEnumerable<LoanViewModel>> GetLoansByUserAsync(Guid userId);
    Task<LoanViewModel> GetLoanByIdAndUserIdAsync(int id, Guid userId);
}