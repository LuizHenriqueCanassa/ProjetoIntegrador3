using ProjetoIntegrador3.Application.ViewModels;
using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Application.Interfaces;

public interface ILoanService
{
    Task<IEnumerable<LoanViewModel>> GetAllLoans();
    Task<LoanViewModel> GetLoanById(int id);
    Task<IEnumerable<LoanViewModel>> GetLoansByUserId(Guid id);
    Task AddRequestLoan(int bookId, Guid userId);
}