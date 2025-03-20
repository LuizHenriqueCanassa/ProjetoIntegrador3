using ProjetoIntegrador3.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.AddEnvironmentConfiguration();

builder.AddIdentityConfiguration();

builder.AddSwaggerConfiguration();

builder.AddHealthCheckConfiguration();

builder.AddDependencyInjectionConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHealthCheckConfiguration();

app.MapControllers();

app.Run();