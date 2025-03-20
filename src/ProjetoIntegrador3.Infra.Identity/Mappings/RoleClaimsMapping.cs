using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoIntegrador3.Infra.Identity.Mappings;

public class RoleClaimsMapping : IEntityTypeConfiguration<IdentityRoleClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
    {
        builder.ToTable("RoleClaims");

        builder.HasData(
            new IdentityRoleClaim<string>
            {
                Id = 1,
                ClaimType = "Root",
                ClaimValue = "Root",
                RoleId = "ab89debc-bb39-46c0-bc36-5a09f243cb07"
            }
        );
    }
}