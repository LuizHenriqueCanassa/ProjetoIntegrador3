using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoIntegrador3.Infra.Identity.Models;

namespace ProjetoIntegrador3.Infra.Identity.Mappings;

public class ApplicationUserMapping : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");
        builder.Property(x => x.FullName).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Birthdate).IsRequired();

        builder.HasData(
            new ApplicationUser
            {
                Id = "5823f86c-aa68-49ca-be02-7adf6bcb291e",
                FullName = "Usuario Root",
                Birthdate = DateTime.Today.ToLocalTime().ToUniversalTime(),
                Email = "root@root.com",
                NormalizedEmail = "ROOT@ROOT.COM",
                UserName = "Root",
                NormalizedUserName = "ROOT",
                EmailConfirmed = true
            }
        );
    }
}