using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Guest.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.MenuAggregate.ValueObjects;
using BubberDinner.Domain.User.ValueObjects;

namespace BubberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId, Guid>
{
#pragma warning disable CS8618 
    public Host()
    {
        
    }
#pragma warning restore CS8618 

    private Host(HostId id,
                 UserId userId,
                 string firstName,
                 string lastName,
                 string profileImage,
                 AverageRating averagRating,
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
    public AverageRating AverageRating { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public UserId UserId { get; private set; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public static Host Create(UserId userId,
                string firstName,
                string lastName,
                string profileImage)
    {
        return new Host(HostId.CreateUnique(),
                         userId,
                         firstName,
                         lastName,
                         profileImage,
                         AverageRating.CreateNew(),
                         DateTime.UtcNow,
                         DateTime.UtcNow);
    }
}
