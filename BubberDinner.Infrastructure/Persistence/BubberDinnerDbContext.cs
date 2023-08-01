using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.MenuAggregate;
using BubberDinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BubberDinner.Infrastructure.Persistence;

public class BubberDinnerDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _interceptor;
    public BubberDinnerDbContext(DbContextOptions<BubberDinnerDbContext> options, PublishDomainEventsInterceptor interceptor)
        : base(options)
    {
        _interceptor = interceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(BubberDinnerDbContext).Assembly);

        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(e => e.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_interceptor);
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Menu> Menus { get; set; } = null!;
}
