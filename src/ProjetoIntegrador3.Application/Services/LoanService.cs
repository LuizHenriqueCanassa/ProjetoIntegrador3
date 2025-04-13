using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProjetoIntegrador3.Application.Exceptions;
using ProjetoIntegrador3.Application.Interfaces;
using ProjetoIntegrador3.Application.ViewModels;
using ProjetoIntegrador3.Domain.Interfaces;
using ProjetoIntegrador3.Domain.Models;
using ProjetoIntegrador3.Domain.Models.Enums;

namespace ProjetoIntegrador3.Application.Services;

public class LoanService : ILoanService
{
    private readonly IMapper _mapper;
    private readonly ILoanRepository _loanRepository;
    private readonly IBookRepository _bookRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoanService(ILoanRepository loanRepository, IMapper mapper, UserManager<ApplicationUser> userManager,
        IBookRepository bookRepository)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
        _userManager = userManager;
        _bookRepository = bookRepository;
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

    public async Task AddRequestLoan(int bookId, Guid userId)
    {
        var book = await _bookRepository.GetById(bookId);

        if (book == null)
            throw new RegisterNotFoundException("Nenhum livro encontrado");
        
        if (BookStatus.Loaned.Equals(book.Status))
            throw new BookInUseException("O livro ainda esta com aluguel vigente");

        var user = await _userManager.FindByIdAsync(userId.ToString());
        
        if (user == null)
            throw new UserNotFoundException("Nenhum usuario encontrado");

        _loanRepository.AddRequestLoan(book, user);
        
        _bookRepository.UpdateStatus(book, BookStatus.Loaned);
    }

    public async Task CancelLoan(int loanId)
    {
        var loan = await _loanRepository.GetLoanById(loanId);
        
        if (loan == null)
            throw new LoanNotFoundException("Nenhum aluguel encontrado");

        if (LoanStatus.CANCELLED.Equals(loan.Status))
            throw new LoanStatusException("Alteraçao de status do aluguel invalida, aluguel ja cancelado");
        
        _loanRepository.CancelLoan(loan);
        
        _bookRepository.UpdateStatus(loan.Book, BookStatus.Available);
    }
}