using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.Host.ValueObjects;

public sealed class HostId : AggregateRootId<Guid>
{
    public HostId()
    {
    }

    public override Guid Value { get; protected set; }

    public HostId(Guid value)
    {
        Value = value;
    }

    public static HostId Create(Guid value)
    {
        return new(value);
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
