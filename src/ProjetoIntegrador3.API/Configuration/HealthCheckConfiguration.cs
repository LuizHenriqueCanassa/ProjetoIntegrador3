namespace ProjetoIntegrador3.API.Configuration;

public static class HealthCheckConfiguration
{
    public static WebApplicationBuilder AddHealthCheckConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks();
        
        return builder;
    }

    public static WebApplication UseHealthCheckConfiguration(this WebApplication app)
    {
        app.UseHealthChecks("/health");
        
        return app;
    }
}