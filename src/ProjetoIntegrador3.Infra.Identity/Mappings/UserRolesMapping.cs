using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoIntegrador3.Infra.Identity.Mappings;

public class UserRolesMapping : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.ToTable("UserRoles");

        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "ab89debc-bb39-46c0-bc36-5a09f243cb07",
                UserId = "5823f86c-aa68-49ca-be02-7adf6bcb291e"
            }
        );
    }
}