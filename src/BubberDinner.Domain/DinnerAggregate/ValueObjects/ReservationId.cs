using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.Dinner.ValueObjects;

public sealed class ReservationId : ValueObject
{
    public Guid Value { get; private set; }

    public ReservationId(Guid value)
    {
        Value = value;
    }

    public static ReservationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
