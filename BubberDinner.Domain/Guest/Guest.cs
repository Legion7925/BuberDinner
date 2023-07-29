using BubberDinner.Domain.Bill.ValueObjects;
using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Guest.Entities;
using BubberDinner.Domain.Guest.ValueObjects;
using BubberDinner.Domain.MenuReview.ValueObjects;
using BubberDinner.Domain.User.ValueObjects;

namespace BubberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    public Guest(GuestId id,
                UserId userId,
                 string firstName,
                 string lastName,
                 string profileImage,
                 double averagRating,
                 DateTime createdDateTime,
                 DateTime updatedDateTime) : base(id)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averagRating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    private readonly List<DinnerId> _upCommingDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<GuestRating> _ratings = new();

    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public double AverageRating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public UserId UserId { get; }

    public IReadOnlyList<DinnerId> UpCommingDinnerIds => _upCommingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();

    public static Guest Create(UserId userId,
                 string firstName,
                 string lastName,
                 string profileImage,
                 double averagRating)
    {
        return new Guest(GuestId.CreateUnique(),
                         userId,
                         firstName,
                         lastName,
                         profileImage,
                         averagRating,
                         DateTime.UtcNow,
                         DateTime.UtcNow);
    }
}
