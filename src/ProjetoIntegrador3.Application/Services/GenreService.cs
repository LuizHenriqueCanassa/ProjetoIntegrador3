using AutoMapper;
using ProjetoIntegrador3.Application.Exceptions;
using ProjetoIntegrador3.Application.Interfaces;
using ProjetoIntegrador3.Application.ViewModels;
using ProjetoIntegrador3.Domain.Interfaces;
using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Application.Services;

public class GenreService : IGenreService
{
    private readonly IMapper _mapper;
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GenreViewModel>> GetAll()
    {
        return _mapper.Map<IEnumerable<GenreViewModel>>(await _genreRepository.GetAll());
    }

    public async Task<GenreViewModel> GetById(int id)
    {
        return _mapper.Map<GenreViewModel>(await _genreRepository.GetById(id));
    }

    public void CreateGenre(CreateUpdateGenreViewModel viewModel)
    {
        _genreRepository.CreateGenre(_mapper.Map<Genre>(viewModel));
    }

    public void UpdateGenre(int id, CreateUpdateGenreViewModel viewModel)
    {
        var genre = _genreRepository.GetById(id).Result;
        
        if (genre == null) throw new RegisterNotFoundException("Genero não encontrado!");
        
        _genreRepository.UpdateGenre(_mapper.Map(viewModel, genre));
    }

    public void DeleteGenre(int id)
    {
        var genre = _genreRepository.GetById(id).Result;

        if (genre == null) throw new RegisterNotFoundException("Genero não encontrado!");
        
        _genreRepository.DeleteGenre(genre);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}