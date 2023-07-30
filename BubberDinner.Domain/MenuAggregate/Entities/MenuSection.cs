using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Menu.ValueObjects;

namespace BubberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{

#pragma warning disable CS8618
    public MenuSection()
    {

    }
#pragma warning restore CS8618

    public MenuSection(MenuSectionId id, string name, string description, List<MenuItem>? items) : base(id)
    {
        Name = name;
        Description = description;
        _items = items ?? new();
    }

    private readonly List<MenuItem> _items = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public static MenuSection Create(string name, string description, List<MenuItem>? items)
    {
        return new(MenuSectionId.CreateUnique(), name, description, items);
    }
}
