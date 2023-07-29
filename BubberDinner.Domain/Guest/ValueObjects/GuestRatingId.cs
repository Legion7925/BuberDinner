using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.Guest.ValueObjects;

public sealed class GuestRatingId : ValueObject
{
    public Guid Value { get; }

    public GuestRatingId(Guid value)
    {
        Value = value;
    }

    public static GuestRatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
