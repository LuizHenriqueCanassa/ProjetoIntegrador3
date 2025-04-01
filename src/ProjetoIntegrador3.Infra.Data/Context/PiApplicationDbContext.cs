using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador3.Infra.Data.Mappings;

namespace ProjetoIntegrador3.Infra.Data.Context;

public class PiApplicationDbContext : DbContext
{
    public PiApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfiguration(new GenreMapping())
            .ApplyConfiguration(new BookMapping());
    }
}