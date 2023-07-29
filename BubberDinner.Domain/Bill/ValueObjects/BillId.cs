using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.MenuReview.ValueObjects;

namespace BubberDinner.Domain.Bill.ValueObjects;

public sealed class BillId : ValueObject
{
    public Guid Value { get; }

    public BillId(Guid value)
    {
        Value = value;
    }

    public static BillId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
