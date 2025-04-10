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

        CreateMap<Loan, LoanViewModel>()
            .ForMember(
                dest => dest.isReturnLate,
                opt => opt.MapFrom(
                    src => src.isReturnLate()
                )
            )
            .ForMember(
                dest => dest.LoanDate,
                opt => opt.MapFrom(
                    src => src.LoanDate.ToString("dd/MM/yyyy")
                )
            )
            .ForMember(
                dest => dest.ReturnDate,
                opt => opt.MapFrom(
                    src => src.ReturnDate != null ? "" : src.ReturnDate.ToString("dd/MM/yyyy")
                )
            )
            .ForPath(
                dest => dest.User.Id,
                opt => opt.MapFrom(
                    src => src.User.Id.ToString()
                )
            )
            .ForPath(
                dest => dest.User.FullName,
                opt => opt.MapFrom(
                    src => src.User.FullName
                )
            )
            .ForPath(
                dest => dest.User.Email,
                opt => opt.MapFrom(
                    src => src.User.FullName
                )
            )
            .ForPath(
                dest => dest.Book.Title,
                opt => opt.MapFrom(
                    src => src.Book.Title
                )
            )
            .ForPath(
                dest => dest.Book.Description,
                opt => opt.MapFrom(
                    src => src.Book.Description
                )
            )
            .ForPath(
                dest => dest.Book.ImageUrl,
                opt => opt.MapFrom(
                    src => src.Book.ImageUrl
                )
            )
            .ForPath(
                dest => dest.Book.Publisher,
                opt => opt.MapFrom(
                    src => src.Book.Publisher
                )
            )
            .ForPath(
                dest => dest.Book.PublishDate,
                opt => opt.MapFrom(
                    src => src.Book.PublishDate.ToString("dd/MM/yyyy")
                )
            )
            .ForPath(
                dest => dest.Book.Isbn,
                opt => opt.MapFrom(
                    src => src.Book.Isbn
                )
            )
            .ForPath(
                dest => dest.Book.Genre,
                opt => opt.MapFrom(
                    src => src.Book.Genre.Name
                )
            )
            .ForPath(
                dest => dest.Book.Status,
                opt => opt.MapFrom(
                    src => src.Book.Status.ToString()
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