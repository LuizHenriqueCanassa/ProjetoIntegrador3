using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Infra.Data.Mappings;

public class BookMapping : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.ImageUrl).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Publisher).HasMaxLength(100).IsRequired();
        builder.Property(x => x.PublishDate).IsRequired();
        builder.Property(x => x.Isbn).HasMaxLength(13).IsRequired();
        builder.Property(x => x.Status).HasConversion<int>().IsRequired();
    }
}