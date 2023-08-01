using BubberDinner.Domain.Host;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.MenuAggregate;
using BubberDinner.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BubberDinner.Infrastructure.Persistence.Configurations;

public class HostConfigurations : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        ConfigureHostTable(builder);
    }

    private static void ConfigureHostTable(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");

        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value)
            );

        builder.Property(m => m.UserId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
            );

        builder.OwnsOne(m => m.AverageRating);

        builder.OwnsMany(h => h.MenuIds, mib =>
        {
            mib.WithOwner().HasForeignKey("HostId");
            mib.HasKey("Id");
            mib.Property(mi => mi.Value)
                .HasColumnName("HostMenuId");
        });

        builder.OwnsMany(d => d.DinnerIds, dib =>
        {
            dib.WithOwner().HasForeignKey("HostId");
            dib.HasKey("Id");
            dib.Property(di => di.Value)
                .HasColumnName("DinnerId");

        });

        builder.Metadata.FindNavigation(nameof(Host.MenuIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Metadata.FindNavigation(nameof(Host.DinnerIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
