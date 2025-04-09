using ProjetoIntegrador3.Application.Interfaces;
using ProjetoIntegrador3.Application.ViewModels;

namespace ProjetoIntegrador3.Application.Services;

public class LoanService : ILoanService
{
    public Task<List<LoanViewModel>> GetLoansByUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<LoanViewModel> GetLoanByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}