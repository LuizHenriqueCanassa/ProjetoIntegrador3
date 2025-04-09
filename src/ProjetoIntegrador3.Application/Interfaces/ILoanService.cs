using ProjetoIntegrador3.Application.ViewModels;

namespace ProjetoIntegrador3.Application.Interfaces;

public interface ILoanService
{
    Task<List<LoanViewModel>> GetLoansByUserAsync(int userId);
    Task<LoanViewModel> GetLoanByIdAsync(int id);
}