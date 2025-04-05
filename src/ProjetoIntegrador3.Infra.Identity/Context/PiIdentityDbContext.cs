using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador3.Infra.Identity.Mappings;
using ProjetoIntegrador3.Infra.Identity.Models;

namespace ProjetoIntegrador3.Infra.Identity.Context;

public class PiIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public PiIdentityDbContext(DbContextOptions<PiIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder
            .ApplyConfiguration(new ApplicationUserMapping())
            .ApplyConfiguration(new UserAddressMapping())
            .ApplyConfiguration(new RoleMapping())
            .ApplyConfiguration(new UserRolesMapping())
            .ApplyConfiguration(new RoleClaimsMapping())
            .ApplyConfiguration(new UserTokenMapping())
            .ApplyConfiguration(new UserLoginMapping())
            .ApplyConfiguration(new UserClaimMapping());
    }
}