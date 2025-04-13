using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Infra.Identity.JWT;

public class JwtBuilder<TIdentityUser, TKey> where TIdentityUser : ApplicationUser where TKey : IEquatable<TKey>
{
    private UserManager<TIdentityUser> _userManager;
    private RoleManager<IdentityRole> _roleManager;
    private AppJwtSettings _appJwtSettings;
    private TIdentityUser _user;
    private ClaimsIdentity _claims;
    private IHttpContextAccessor _httpContext;

    public JwtBuilder<TIdentityUser, TKey> WithHttpContext(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
        return this;
    }

    public JwtBuilder<TIdentityUser, TKey> WithUserManager(UserManager<TIdentityUser> userManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        return this;
    }

    public JwtBuilder<TIdentityUser, TKey> WithRoleManager(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        return this;
    }

    public JwtBuilder<TIdentityUser, TKey> WithAppJwtSettings(AppJwtSettings appJwtSettings)
    {
        _appJwtSettings = appJwtSettings ?? throw new ArgumentNullException(nameof(appJwtSettings));
        return this;
    }

    public JwtBuilder<TIdentityUser, TKey> WithEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));

        _user = _userManager.FindByEmailAsync(email).Result;
        _claims = new ClaimsIdentity();

        return this;
    }

    public JwtBuilder<TIdentityUser, TKey> WithRoleClaims()
    {
        _claims.AddClaim(new Claim(ClaimTypes.Name, _user.UserName));

        var roles = _userManager.GetRolesAsync(_user).Result;

        foreach (var roleName in roles)
        {
            var role = _roleManager.FindByNameAsync(roleName).Result;
            _claims.AddClaim(new Claim(ClaimTypes.Role, role.Name));
            _claims.AddClaims(_roleManager.GetClaimsAsync(role).Result);
        }

        return this;
    }

    public object GenerateToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appJwtSettings.SecretKey);

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = _claims,
            Issuer = _appJwtSettings.Issuer,
            Audience = _httpContext.HttpContext.Request.Scheme + "://" + _httpContext.HttpContext.Request.Host.Host,
            Expires = DateTime.UtcNow.AddHours(_appJwtSettings.Expiration),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        });

        return new
        {
            AccessToken = tokenHandler.WriteToken(token),
            ExpiresIn = TimeSpan.FromHours(_appJwtSettings.Expiration).TotalSeconds,
            UserToken = new
            {
                _user.Id,
                _user.Email,
                _user.FullName,
                Role = _claims.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value),
                Claims = _claims.Claims.GroupBy(c => c.Type)
                    .Where(c => !(c.Key is ClaimTypes.Name) && c.Key != ClaimTypes.Role).Select(cv => new
                    {
                        Type = cv.Key, Values = cv.Select(c => c.Value).ToList()
                    })
                    .ToList()
            }
        };
    }
}

public class JwtBuilder<TIdentityUser> : JwtBuilder<TIdentityUser, string> where TIdentityUser : ApplicationUser
{
}

public sealed class JwtBuilder : JwtBuilder<ApplicationUser>
{
}