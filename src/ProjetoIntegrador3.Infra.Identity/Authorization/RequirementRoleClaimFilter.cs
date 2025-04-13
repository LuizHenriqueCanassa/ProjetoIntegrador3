using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using ProjetoIntegrador3.Domain.Models;
using ProjetoIntegrador3.Infra.Identity.JWT;

namespace ProjetoIntegrador3.Infra.Identity.Authorization;

public class RequirementRoleClaimFilter : IAuthorizationFilter
{
    private readonly Claim _claim;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AppJwtSettings _appJwtSettings;

    public RequirementRoleClaimFilter(Claim claim, UserManager<ApplicationUser> userManager, IOptions<AppJwtSettings> appJwtSettings)
    {
        _claim = claim;
        _userManager = userManager;
        _appJwtSettings = appJwtSettings.Value;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = _userManager.FindByNameAsync(context.HttpContext.User.Identity.Name).Result;
        
        context.HttpContext.Request.Headers.TryGetValue("Authorization", out var jwtToken);

        var token = _userManager.GetAuthenticationTokenAsync(user, _appJwtSettings.Issuer, "JWT").Result;

        if (token == null)
        {
            context.Result = new StatusCodeResult(401);
            return;
        }
        
        if (jwtToken.ToString().Replace("Bearer ", "") != token)
        {
            context.Result = new StatusCodeResult(401);
            return;
        }
        
        if (context.HttpContext.User.Identity == null)
            throw new InvalidOperationException();

        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new StatusCodeResult(401);
            return;
        }

        if (!CustomAuthorizationValidation.ValidateUserRoleClaims(context.HttpContext, _claim.Type, _claim.Value))
        {
            context.Result = new StatusCodeResult(403);
        }
    }
}