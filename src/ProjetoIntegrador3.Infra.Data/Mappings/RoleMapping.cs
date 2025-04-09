using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoIntegrador3.Infra.Data.Mappings;

public class RoleMapping : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.ToTable("Roles");

        builder.HasData(
            new IdentityRole
            {
                Id = "ab89debc-bb39-46c0-bc36-5a09f243cb07", Name = "Root", NormalizedName = "ROOT",
                ConcurrencyStamp = "351cb829-f5e2-4a5f-b991-59a8e46c3169"
            },
            new IdentityRole
            {
                Id = "6a8fc41d-a018-4533-9da1-a9bca7f65b09", Name = "Admin", NormalizedName = "ADMIN",
                ConcurrencyStamp = "347abcd1-2d78-4f91-86ff-606af3620f17"
            },
            new IdentityRole
            {
                Id = "bc82410f-d883-49b7-86be-7b8e5050fda4", Name = "Employee", NormalizedName = "EMPLOYEE",
                ConcurrencyStamp = "59ebb24e-e168-44ac-a197-a5769622c1fb"
            },
            new IdentityRole
            {
                Id = "373df597-9ca9-4597-95d9-ab18f156021e", Name = "User", NormalizedName = "USER",
                ConcurrencyStamp = "0201f907-f05b-46db-9c4a-8d6bf98e8690"
            }
        );
    }
}