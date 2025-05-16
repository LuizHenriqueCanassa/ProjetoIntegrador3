using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ProjetoIntegrador3.Domain.Models;
using ProjetoIntegrador3.Infra.Data.Context;
using ProjetoIntegrador3.Infra.Identity.JWT;

namespace ProjetoIntegrador3.API.Configuration;

public static class IdentityConfiguration
{
    public static WebApplicationBuilder AddIdentityConfiguration(this WebApplicationBuilder builder)
    {
        
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<PiApplicationDbContext>();
        
        var appJwtSettingsSection = builder.Configuration.GetSection("AppJwtSettings");
        builder.Services.Configure<AppJwtSettings>(appJwtSettingsSection);
        
        var appJwtSettings = appJwtSettingsSection.Get<AppJwtSettings>();
        var key = Encoding.ASCII.GetBytes(appJwtSettings.SecretKey);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = false,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidAudiences = appJwtSettings.Audience,
                ValidIssuer = appJwtSettings.Issuer
            };
        });
        
        return builder;
    }
}