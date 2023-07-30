using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.Dinner.ValueObjects;

public sealed class DinnerId : ValueObject
{
    public DinnerId()
    {
    }
    public Guid Value { get; private set; }

    public DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
