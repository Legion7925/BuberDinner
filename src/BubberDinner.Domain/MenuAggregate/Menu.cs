using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.MenuAggregate.Entities;
using BubberDinner.Domain.MenuAggregate.Events;
using BubberDinner.Domain.MenuAggregate.ValueObjects;
using BubberDinner.Domain.MenuReview.ValueObjects;

namespace BubberDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId , Guid>
{
    private Menu(MenuId id,
                HostId hostId,
                string name,
                string description,
                DateTime createdDateTime,
                DateTime updatedDateTime,
                AverageRating averageRating,
                List<MenuSection> sections) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        _menuSections = sections;
        AverageRating = averageRating;
    }

    private readonly List<MenuSection> _menuSections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; }    
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }


    public HostId HostId { get; private set; }

    public IReadOnlyList<MenuSection> MenuSections => _menuSections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();


    public static Menu Create(string name,
                              string description,
                              HostId hostId,
                              List<MenuSection>? sections)
    {
       var menu = new Menu(MenuId.CreateUnique(),
                        hostId,
                        name,
                        description,
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                        AverageRating.CreateNew(),
                        sections ?? new());

        menu.AddDomainEvent(new MenuCreated(menu));

        return menu;
    }

#pragma warning disable CS8618
    private Menu()
    {
    }
#pragma warning restore CS8618
}
