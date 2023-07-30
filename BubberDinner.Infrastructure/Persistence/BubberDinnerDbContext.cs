using BubberDinner.Domain.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BubberDinner.Infrastructure.Persistence;

public class BubberDinnerDbContext : DbContext
{
    public BubberDinnerDbContext(DbContextOptions<BubberDinnerDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(BubberDinnerDbContext).Assembly);

        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(e => e.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Menu> Menus { get; set; } = null!;
}
