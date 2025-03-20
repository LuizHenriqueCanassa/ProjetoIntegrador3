using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoIntegrador3.Infra.Identity.Models;

namespace ProjetoIntegrador3.Infra.Identity.Mappings;

public class UserAddressMapping : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.ToTable("AspNetUserAddress");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.StreetAddress).HasMaxLength(100).IsRequired();
        
        builder.Property(x => x.StreetNumber).IsRequired();
        
        builder.Property(x => x.City).IsRequired().HasMaxLength(100);
        
        builder.Property(x => x.State).IsRequired().HasMaxLength(2);
        
        builder.Property(x => x.Zip).IsRequired().HasMaxLength(8);
    }
}