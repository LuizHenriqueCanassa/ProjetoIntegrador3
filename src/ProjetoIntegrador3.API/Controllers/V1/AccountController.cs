using Asp.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProjetoIntegrador3.Application.ViewModels.User;
using ProjetoIntegrador3.Domain.Models;
using ProjetoIntegrador3.Infra.Identity.JWT;

namespace ProjetoIntegrador3.API.Controllers.V1;

[ApiVersion("1.0")]
[ApiController]
[Route("/api/v{version:apiVersion}/account")]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IHttpContextAccessor _httpContext;
    private readonly AppJwtSettings _appJwtSettings;
    
    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContext, IOptions<AppJwtSettings> appJwtSettings, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _httpContext = httpContext;
        _roleManager = roleManager;
        _appJwtSettings = appJwtSettings.Value;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserViewModel loginUserViewModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var result = await _signInManager.PasswordSignInAsync(loginUserViewModel.Email, loginUserViewModel.Password, false, false);
        
        if (!result.Succeeded) return BadRequest(result);
        
        return Ok(GetJwtToken(loginUserViewModel.Email));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserViewModel registerUserViewModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = new ApplicationUser
        {
            FullName = registerUserViewModel.FullName,
            Birthdate = registerUserViewModel.Birthdate.ToUniversalTime(),
            Email = registerUserViewModel.Email,
            NormalizedEmail = registerUserViewModel.Email.ToUpper(),
            UserName = registerUserViewModel.Email,
            NormalizedUserName = registerUserViewModel.Email.ToUpper(),
            EmailConfirmed = true
        };
        
        var result = await _userManager.CreateAsync(user, registerUserViewModel.Password);
        
        if (!result.Succeeded) return BadRequest(result.Errors);
        
        await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(user.Email), "User");
        
        return Created();
    }

    private object GetJwtToken(string email)
    {
        return new JwtBuilder()
            .WithHttpContext(_httpContext)
            .WithUserManager(_userManager)
            .WithRoleManager(_roleManager)
            .WithAppJwtSettings(_appJwtSettings)
            .WithEmail(email)
            .WithRoleClaims()
            .GenerateToken();
    }
}