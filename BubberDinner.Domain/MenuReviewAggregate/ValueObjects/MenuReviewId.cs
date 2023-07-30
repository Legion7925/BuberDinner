using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.MenuReview.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    public MenuReviewId()
    {
    }

    public Guid Value { get; private set; }

    public MenuReviewId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
