using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Infra.Data.Mappings;

public class ApplicationUserMapping : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");
        builder.Property(x => x.FullName).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Birthdate).IsRequired();
    }
}