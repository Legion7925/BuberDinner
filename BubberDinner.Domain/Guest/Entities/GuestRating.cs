using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Guest.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;

namespace BubberDinner.Domain.Guest.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    public GuestRating(GuestRatingId id,
                       HostId hostId,
                       DinnerId dinnerId,
                       double rating,
                       DateTime createdDateTime,
                       DateTime updatedDateTime) : base(id)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public double Rating { get; }

    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public static GuestRating Create(HostId hostId,DinnerId dinnerId,double rating)
    {
        return new GuestRating(GuestRatingId.CreateUnique(), hostId, dinnerId, rating, DateTime.UtcNow, DateTime.UtcNow);
    }
}
