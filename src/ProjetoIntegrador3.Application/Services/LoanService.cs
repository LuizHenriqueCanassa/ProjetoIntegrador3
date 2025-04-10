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

    public async Task<IEnumerable<LoanViewModel>> GetLoansByUserAsync(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        
        if (user is null) throw new UserNotFoundException("Usuário não encontrado");

        return _mapper.Map<IEnumerable<LoanViewModel>>(await _loanRepository.GetAllByUser(user));
    }

    public async Task<LoanViewModel> GetLoanByIdAndUserIdAsync(int id, Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        
        if (user is null) throw new UserNotFoundException("Usuário não encontrado");

        var loan = await _loanRepository.GetByIdAndUser(id, user);
        
        if (loan == null) throw new LoanNotFoundException("Aluguel não encontrado");
        
        return _mapper.Map<LoanViewModel>(loan);
    }
}