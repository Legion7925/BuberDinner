using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.Menu.ValueObjects;

public sealed class MenuId : ValueObject
{
    public MenuId()
    {
    }

    public Guid Value { get; private set; }

    public MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuId Create(Guid id)
    {
        return new(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
