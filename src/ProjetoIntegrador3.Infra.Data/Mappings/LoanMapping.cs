using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoIntegrador3.Domain.Models;

namespace ProjetoIntegrador3.Infra.Data.Mappings;

public class LoanMapping : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("Loans");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status).HasConversion<int>().IsRequired();
        builder.Property(x => x.LoanDate).HasColumnType("date").IsRequired();
        builder.Property(x => x.ReturnDate).HasColumnType("date").IsRequired();
        builder.Property(x => x.DateReturned).HasColumnType("date").IsRequired();
    }
}