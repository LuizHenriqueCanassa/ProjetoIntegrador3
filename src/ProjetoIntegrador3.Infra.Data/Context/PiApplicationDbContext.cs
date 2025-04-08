using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador3.Domain.Models;
using ProjetoIntegrador3.Infra.Data.Mappings;

namespace ProjetoIntegrador3.Infra.Data.Context;

public class PiApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public PiApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfiguration(new ApplicationUserMapping())
            .ApplyConfiguration(new UserAddressMapping())
            .ApplyConfiguration(new RoleMapping())
            .ApplyConfiguration(new UserRolesMapping())
            .ApplyConfiguration(new RoleClaimsMapping())
            .ApplyConfiguration(new UserTokenMapping())
            .ApplyConfiguration(new UserLoginMapping())
            .ApplyConfiguration(new UserClaimMapping())
            .ApplyConfiguration(new GenreMapping())
            .ApplyConfiguration(new BookMapping());
    }
}