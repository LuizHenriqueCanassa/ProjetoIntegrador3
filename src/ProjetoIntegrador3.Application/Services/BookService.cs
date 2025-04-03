using AutoMapper;
using ProjetoIntegrador3.Application.Exceptions;
using ProjetoIntegrador3.Application.Interfaces;
using ProjetoIntegrador3.Application.ViewModels;
using ProjetoIntegrador3.Domain.Interfaces;
using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Application.Services;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;
    private readonly IGenreRepository _genreRepository;

    public BookService(IBookRepository bookRepository, IMapper mapper, IGenreRepository genreRepository)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<BookViewModel>> GetAll()
    {
        return _mapper.Map<IEnumerable<BookViewModel>>(await _bookRepository.GetAll());
    }

    public async Task<BookViewModel> GetById(int id)
    {
        var book = await _bookRepository.GetById(id);

        if (book == null) throw new RegisterNotFoundException($"Livro não encontrado pelo ID: {id}");

        return _mapper.Map<BookViewModel>(book);
    }

    public void Create(CreateUpdateBookViewModel viewModel)
    {
        var genre = _genreRepository.GetById(viewModel.GenreId).Result;

        if (genre == null) throw new RegisterNotFoundException("Genero não encontrado!");

        var book = _mapper.Map<Book>(viewModel);
        
        book.Genre = genre;
        
        _bookRepository.Create(book);
    }

    public void Update(int id, CreateUpdateBookViewModel viewModel)
    {
        var book = _bookRepository.GetById(id).Result;

        if (book == null) throw new RegisterNotFoundException("Livro não encontrado!");
        
        var genre = _genreRepository.GetById(viewModel.GenreId).Result;
        
        if (genre == null) throw new RegisterNotFoundException("Genero não encontrado!");
        
        book.Genre = genre;
        
        _bookRepository.Update(_mapper.Map(viewModel, book));
    }

    public void Delete(int id)
    {
        var book = _bookRepository.GetById(id).Result;

        if (book == null) throw new RegisterNotFoundException("Livro não encontrado!");
        
        _bookRepository.Delete(book);
    }
}