﻿using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.Common.ValueObjects;

public sealed class Price : ValueObject
{

#pragma warning disable CS8618 
    public Price()
    {
    }
#pragma warning restore CS8618 

    public double Amount { get; private set; }
    public string Currency { get; private set; }

    public Price(double amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Price Create(double amount, string currency)
    {
        return new Price(amount, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
