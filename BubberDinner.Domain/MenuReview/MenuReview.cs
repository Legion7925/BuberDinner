using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Guest.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.Menu.ValueObjects;
using BubberDinner.Domain.MenuReview.ValueObjects;

namespace BubberDinner.Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public MenuReview(MenuReviewId id,
                      HostId hostId,
                      MenuId menuId,
                      GuestId guestId,
                      DinnerId dinnerId,
                      double rating,
                      string comment,
                      DateTime createdDateTime,
                      DateTime updatedDateTime) : base(id)
    {
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        Rating = rating;
        Comment = comment;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public double Rating { get; }
    public string Comment { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }

    public static MenuReview Create(HostId hostId,
                      MenuId menuId,
                      GuestId guestId,
                      DinnerId dinnerId,
                      double rating,
                      string comment)
    {
        return new MenuReview(MenuReviewId.CreateUnique(),
                              hostId,
                              menuId,
                              guestId,
                              dinnerId,
                              rating,
                              comment,
                              DateTime.UtcNow,
                              DateTime.UtcNow);
    }
}
