using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoIntegrador3.Infra.Identity.Context;
using ProjetoIntegrador3.Infra.Identity.JWT;
using ProjetoIntegrador3.Infra.Identity.Models;

namespace ProjetoIntegrador3.API.Configuration;

public static class IdentityConfiguration
{
    public static WebApplicationBuilder AddIdentityConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<PiIdentityDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        
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
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudiences = appJwtSettings.Audience,
                ValidIssuer = appJwtSettings.Issuer
            };
        });

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<PiIdentityDbContext>();
        
        return builder;
    }
}