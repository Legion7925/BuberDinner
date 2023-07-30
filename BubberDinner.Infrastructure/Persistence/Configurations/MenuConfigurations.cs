using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.Menu;
using BubberDinner.Domain.Menu.Entities;
using BubberDinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BubberDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenusSectionsTable(builder);
        ConfigureMenuDinnerIds(builder);
        ConfigureMenuReviewIds(builder);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value)
            );

        builder.Property(m => m.Name).HasMaxLength(100);
        builder.Property(m => m.Description).HasMaxLength(100);

        builder.OwnsOne(m => m.AverageRating);

        builder.Property(m => m.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value)
            );
    }

    private void ConfigureMenusSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuSections, sb =>
        {
            sb.ToTable("MenuSections");

            sb.WithOwner().HasForeignKey("MenuId");

            sb.HasKey(nameof(MenuSection.Id), "MenuId");

            sb.Property(m => m.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

            sb.Property(s => s.Name).HasMaxLength(100);
            sb.Property(s => s.Description).HasMaxLength(100);

            sb.OwnsMany(s => s.Items , ib=>
            {
                ib.ToTable("MenuItems");

                ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                ib.Property(i => i.Id)
                    .HasColumnName("MenuItemId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value)
                    );

                ib.Property(i => i.Name).HasMaxLength(100);
                ib.Property(i => i.Description).HasMaxLength(100);

            });

            sb.Navigation(s => s.Items).Metadata.SetField("_items");
            sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuSections))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuReviewIds(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, mi =>
        {
            mi.ToTable("MenuReviewIds");

            mi.WithOwner().HasForeignKey("MenuId");

            mi.HasKey("Id");

            mi.Property(d => d.Value)
                .HasColumnName("MenuReviewId")
                .ValueGeneratedNever();

        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIds(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, di =>
        {
            di.ToTable("MenuDinnerIds");

            di.WithOwner().HasForeignKey("MenuId");

            di.HasKey("Id");

            di.Property(d => d.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();

        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
    