using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProjetoIntegrador3.Application.Exceptions;
using ProjetoIntegrador3.Application.Interfaces;
using ProjetoIntegrador3.Application.ViewModels;
using ProjetoIntegrador3.Domain.Interfaces;
using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Application.Services;

public class LoanService : ILoanService
{
    private readonly IMapper _mapper;
    private readonly ILoanRepository _loanRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoanService(ILoanRepository loanRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<IEnumerable<LoanViewModel>> GetAllLoans()
    {
        return _mapper.Map<IEnumerable<LoanViewModel>>(await _loanRepository.GetAllLoans());
    }

    public async Task<LoanViewModel> GetLoanById(int id)
    {
        var loan = await _loanRepository.GetLoanById(id);

        if (loan == null) throw new LoanNotFoundException("Nenhum aluguel encontrado");
        
        return _mapper.Map<LoanViewModel>(loan);
    }

    public async Task<IEnumerable<LoanViewModel>> GetLoansByUserId(Guid id)
    {
        return _mapper.Map<IEnumerable<LoanViewModel>>(await _loanRepository.GetLoansByUserId(id));
    }
}