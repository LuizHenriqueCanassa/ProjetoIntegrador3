using ProjetoIntegrador3.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.AddEnvironmentConfiguration();

builder.AddSwaggerConfiguration();

builder.AddHealthCheckConfiguration();

builder.AddDependencyInjectionConfiguration();

builder.AddIdentityConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseHealthCheckConfiguration();

app.MapControllers();

app.Run();