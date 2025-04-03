using ProjetoIntegrador3.Application.AutoMapper;

namespace ProjetoIntegrador3.API.Configuration;

public static class AutoMapperConfiguration
{
    public static WebApplicationBuilder AddAutoMapperConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(
            typeof(DomainToViewMappingProfile), 
            typeof(ViewModelToDomainMappingProfile)
            );
        
        return builder;
    }
}