using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador3.Infra.Identity.Models;

namespace ProjetoIntegrador3.Infra.Identity.Context;

public class PiIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public PiIdentityDbContext(DbContextOptions options) : base(options)
    {
    }
}