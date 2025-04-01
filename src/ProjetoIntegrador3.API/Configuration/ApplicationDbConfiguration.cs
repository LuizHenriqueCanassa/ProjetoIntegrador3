using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador3.Infra.Data.Context;

namespace ProjetoIntegrador3.API.Configuration;

public static class ApplicationDbConfiguration
{
    public static WebApplicationBuilder AddApplicationDbConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<PiApplicationDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        
        return builder;
    }
}