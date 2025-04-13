using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Infra.Data.Mappings;

public class UserAddressMapping : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder)builder, "UserAddresses");
            
        builder.HasKey(x => x.Id);
            
        builder.Property(x => x.StreetAddress).HasMaxLength(200).IsRequired();
        builder.Property(x => x.City).HasMaxLength(200).IsRequired();
        builder.Property(x => x.State).HasColumnType("char").HasMaxLength(2).IsRequired();
        builder.Property(x => x.Zip).HasColumnType("char").HasMaxLength(11).IsRequired();
    }
}