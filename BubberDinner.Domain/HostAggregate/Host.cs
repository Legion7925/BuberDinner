using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Guest.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.Menu.ValueObjects;
using BubberDinner.Domain.User.ValueObjects;

namespace BubberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    private Host(HostId id,
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
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImage { get; private set; }
    public double AverageRating { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public UserId UserId { get; private set; }
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
