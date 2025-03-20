using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoIntegrador3.Infra.Identity.Mappings;

public class RoleMapping : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.ToTable("Roles");

        builder.HasData(
            new IdentityRole
            {
                Id = "ab89debc-bb39-46c0-bc36-5a09f243cb07", Name = "Root", NormalizedName = "ROOT",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Id = "b894005b-2a24-4b4a-8182-2a8e90c74c7e", Name = "Admin", NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Id = "63250c55-69c6-4a4b-8788-428de5ea3ca7", Name = "Employee", NormalizedName = "EMPLOYEE",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Id = "63dec552-5279-4728-ab19-6a97b2bd25c9", Name = "User", NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        );
    }
}