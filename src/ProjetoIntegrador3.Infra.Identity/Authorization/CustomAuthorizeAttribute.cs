using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoIntegrador3.Infra.Identity.Authorization;

public class CustomAuthorizeAttribute : TypeFilterAttribute
{
    public CustomAuthorizeAttribute(string claimType, string claimValue) : base(typeof(RequirementRoleClaimFilter))
    {
        Arguments = new object[] { new Claim(claimType, claimValue) };
    }
}