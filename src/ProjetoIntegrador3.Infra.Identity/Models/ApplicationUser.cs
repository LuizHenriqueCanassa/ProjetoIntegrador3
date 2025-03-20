using Microsoft.AspNetCore.Identity;

namespace ProjetoIntegrador3.Infra.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    public DateTime Birthdate { get; set; }
    public IEnumerable<UserAddress>? Addresses { get; set; } = new List<UserAddress>();
}