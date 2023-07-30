using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Guest.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.Menu.ValueObjects;
using BubberDinner.Domain.MenuReview.ValueObjects;

namespace BubberDinner.Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
#pragma warning disable CS8618 
    public MenuReview()
    {
    }
#pragma warning restore CS8618 

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

    public double Rating { get; private set; }
    public string Comment { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public GuestId GuestId { get; private set; }
    public DinnerId DinnerId { get; private set; }

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
