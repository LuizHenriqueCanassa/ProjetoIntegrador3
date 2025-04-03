using AutoMapper;
using ProjetoIntegrador3.Application.ViewModels;
using ProjetoIntegrador3.Domain.Models;

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
            );
    }
}