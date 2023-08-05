using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public Rating()
    {
    }

    public float Value { get; private set; }

    public Rating(float value)
    {
        Value = value;
    }

    public static Rating CreateUnique(float rating = 0)
    {
        return new(rating);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
