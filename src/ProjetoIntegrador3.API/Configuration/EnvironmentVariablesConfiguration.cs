namespace ProjetoIntegrador3.API.Configuration;

public static class EnvironmentVariablesConfiguration
{
    public static WebApplicationBuilder AddEnvironmentConfiguration(this WebApplicationBuilder builder)
    {
        builder.Configuration
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();
        
        return builder;
    }
}