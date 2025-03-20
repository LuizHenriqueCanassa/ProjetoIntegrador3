using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador3.Infra.Identity.Mappings;
using ProjetoIntegrador3.Infra.Identity.Models;

namespace ProjetoIntegrador3.Infra.Identity.Context;

public class PiIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public PiIdentityDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityUserToken<string>>().Metadata.SetIsTableExcludedFromMigrations(true);
        builder.Entity<IdentityUserLogin<string>>().Metadata.SetIsTableExcludedFromMigrations(true);
        builder.Entity<IdentityUserClaim<string>>().Metadata.SetIsTableExcludedFromMigrations(true);

        builder
            .ApplyConfiguration(new ApplicationUserMapping())
            .ApplyConfiguration(new UserAddressMapping())
            .ApplyConfiguration(new RoleMapping())
            .ApplyConfiguration(new UserRolesMapping())
            .ApplyConfiguration(new RoleClaimsMapping());
    }
}