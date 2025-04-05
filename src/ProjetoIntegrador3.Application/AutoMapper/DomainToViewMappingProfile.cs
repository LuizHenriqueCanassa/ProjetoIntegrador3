using AutoMapper;
using ProjetoIntegrador3.Application.Exceptions;
using ProjetoIntegrador3.Application.ViewModels;
using ProjetoIntegrador3.Domain.Models;
using ProjetoIntegrador3.Domain.Models.Enums;

namespace ProjetoIntegrador3.Application.AutoMapper;

public class DomainToViewMappingProfile : Profile
{
    public DomainToViewMappingProfile()
    {
        CreateMap<Genre, GenreViewModel>()
            .ForMember(
                dest => dest.CreationDate,
                opt => opt.MapFrom(
                    src => src.CreationDate.ToString("dd/MM/yyyy"))
            );

        CreateMap<Book, BookViewModel>()
            .ForMember(
                dest => dest.Genre,
                opt => opt.MapFrom(
                    src => src.Genre.Name
                )
            )
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(
                    src => ToBookStatusDescription(src.Status)
                )
            );
    }

    private string ToBookStatusDescription(BookStatus status)
    {
        if (BookStatus.Available.Equals(status))
        {
            return "Disponível";
        }

        if (BookStatus.Loaned.Equals(status))
        {
            return "Emprestado";
        }

        throw new BookStatusException("Status invalido");
    }
}