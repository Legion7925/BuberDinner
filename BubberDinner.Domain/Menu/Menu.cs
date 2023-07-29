using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.Menu.Entities;
using BubberDinner.Domain.Menu.ValueObjects;
using BubberDinner.Domain.MenuReview.ValueObjects;

namespace BubberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    public Menu(MenuId id,
                HostId hostId,
                string name,
                string description,
                string averageRating,
                DateTime createdDateTime,
                DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    private readonly List<MenuSection> _menuSections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string Name { get; }
    public string Description { get; }
    public string AverageRating { get; }
    public IReadOnlyList<MenuSection> MenuSections => _menuSections.AsReadOnly();

    public HostId HostId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public static Menu Create(string name,
                              string description,
                              string averageRating,
                              HostId hostId)
    {
        return new Menu(MenuId.CreateUnique(),
                        hostId,
                        name,
                        description,
                        averageRating,
                        DateTime.UtcNow,
                        DateTime.UtcNow);
    }
}
