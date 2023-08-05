namespace BubberDinner.Domain.Common.Models;

public abstract class AggregateRoot<TId , TIdType> : Entity<TId>
    where TId : AggregateRootId<TIdType>
{
    public new AggregateRootId<TIdType> Id { get; protected set; }

#pragma warning disable CS8618
    protected AggregateRoot()
    {
    }
#pragma warning restore CS8618 

    protected AggregateRoot(TId id) : base(id)
    {
        Id = id;
    }
}
