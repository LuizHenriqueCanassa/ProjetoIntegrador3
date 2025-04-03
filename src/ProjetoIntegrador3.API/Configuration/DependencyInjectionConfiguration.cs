using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using ProjetoIntegrador3.Application.Interfaces;
using ProjetoIntegrador3.Application.Services;
using ProjetoIntegrador3.Domain.Interfaces;
using ProjetoIntegrador3.Infra.Data.Context;
using ProjetoIntegrador3.Infra.Data.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProjetoIntegrador3.API.Configuration;

public static class DependencyInjectionConfiguration
{
    public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
    {
        //Aplication
        builder.Services.AddScoped<IGenreService, GenreService>();
        builder.Services.AddScoped<IBookService, BookService>();
        
        builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
        //Infra - Data
        builder.Services.AddScoped<IGenreRepository, GenreRepository>();
        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<PiApplicationDbContext>();
        
        return builder;
    }
}