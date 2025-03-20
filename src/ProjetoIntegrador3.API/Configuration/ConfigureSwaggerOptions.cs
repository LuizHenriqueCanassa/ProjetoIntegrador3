using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProjetoIntegrador3.API.Configuration;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                new OpenApiInfo
                {
                    Title = "Projeto Integrador 3",
                    Version = description.ApiVersion.ToString(),
                    Description = "Projeto Integrador 3 - Univesp",
                    TermsOfService = new Uri("https://opensource.org/licenses/MIT"),
                    Contact = new OpenApiContact {Name = "Grupo Projeto Integrador 3", Email = "sememail@email.com"},
                    License = new OpenApiLicense {Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT")}
                }
                );
        }
    }
}