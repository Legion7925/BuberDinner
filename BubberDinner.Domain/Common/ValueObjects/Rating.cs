using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public double Value { get; }

    public Rating(double value)
    {
        Value = value;
    }

    public static Rating CreateUnique(double rating = 0)
    {
        return new(rating);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
