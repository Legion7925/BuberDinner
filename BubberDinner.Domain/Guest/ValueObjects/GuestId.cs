﻿using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.MenuReview.ValueObjects;

namespace BubberDinner.Domain.Guest.ValueObjects;

public sealed class GuestId : ValueObject
{
    public Guid Value { get; }

    public GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}