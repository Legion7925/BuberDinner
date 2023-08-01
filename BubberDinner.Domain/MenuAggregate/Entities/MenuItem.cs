using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.MenuAggregate.ValueObjects;

namespace BubberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
#pragma warning disable CS8618
    private MenuItem()
    {        
    }
#pragma warning restore CS8618

    public MenuItem(MenuItemId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }

    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }
}
