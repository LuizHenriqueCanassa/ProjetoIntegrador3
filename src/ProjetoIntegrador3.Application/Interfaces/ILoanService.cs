using ProjetoIntegrador3.Application.ViewModels;
using ProjetoIntegrador3.Domain.Models;
using ProjetoIntegrador3.Domain.Models.Enums;

namespace ProjetoIntegrador3.Application.Interfaces;

public interface ILoanService
{
    Task<IEnumerable<LoanViewModel>> GetAllLoans();
    Task<LoanViewModel> GetLoanById(int id);
    Task<IEnumerable<LoanViewModel>> GetLoansByUserId(Guid id);
    Task AddRequestLoan(int bookId, Guid userId);
    Task CancelLoan(int loanId); 
    Task UpdateLoanStatus(int loanId, LoanStatus loanStatus);
}