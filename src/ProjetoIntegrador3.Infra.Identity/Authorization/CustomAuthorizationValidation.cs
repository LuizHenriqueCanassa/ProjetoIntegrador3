using Microsoft.AspNetCore.Http;

namespace ProjetoIntegrador3.Infra.Identity.Authorization;

public class CustomAuthorizationValidation
{
    public static bool ValidateUserRoleClaims(HttpContext context, string claimType, string claimValue)
    {
        if (context.User.Identity == null) throw new InvalidOperationException("User has not been authenticated.");
        
        if (context.User.Identity.IsAuthenticated && context.User.Claims.Any(c => c.Type == "Root")) return true;
        
        return context.User.Identity.IsAuthenticated
            && context.User.Claims.Any(c => c.Type == claimType && c.Value.Contains(claimValue));
    }
}