using BubberDinner.Domain.Common.Models;

namespace BubberDinner.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    public AverageRating()
    {
    }

    public AverageRating(float value , int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }
    public float Value { get; private set; }
    public int NumRatings { get; private set; }

    public static AverageRating CreateNew(float ratings = 0 , int numRatings = 0)
    {
        return new AverageRating(ratings, numRatings);
    }

    public void AddNewRating(Rating rating)
    {
        Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
    }

    public void RemoveRating(Rating rating)
    {
        Value = ((Value * NumRatings) -  rating.Value) / --NumRatings;  
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
