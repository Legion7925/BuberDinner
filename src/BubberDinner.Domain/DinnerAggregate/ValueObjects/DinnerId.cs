using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.Dinner.ValueObjects;

public sealed class DinnerId : AggregateRootId<Guid>
{
    public DinnerId()
    {
    }
    public override Guid Value { get; protected set; }

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
