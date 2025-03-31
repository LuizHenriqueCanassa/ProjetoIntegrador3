using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador3.Infra.Identity.Authorization;

namespace ProjetoIntegrador3.API.Controllers.V1;

[ApiVersion("1.0")]
[ApiController]
[Authorize]
[Route("/api/v{version:apiVersion}/[controller]")]
public class TesteAuthenticationController : ControllerBase
{
    [CustomAuthorize("Root", "Root")]
    [HttpGet("root-permission")]
    public string TesteRootPermission()
    {
        return "Foi";
    }
}