using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Guest.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.Menu.ValueObjects;
using BubberDinner.Domain.User.ValueObjects;

namespace BubberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    public Host(HostId id,
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

    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public double AverageRating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public UserId UserId { get; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public static Host Create(UserId userId,
                string firstName,
                string lastName,
                string profileImage,
                double averagRating)
    {
        return new Host(HostId.CreateUnique(),
                         userId,
                         firstName,
                         lastName,
                         profileImage,
                         averagRating,
                         DateTime.UtcNow,
                         DateTime.UtcNow);
    }
}
