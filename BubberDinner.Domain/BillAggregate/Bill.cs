using BubberDinner.Domain.Bill.ValueObjects;
using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Guest.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;

namespace BubberDinner.Domain.Bill;

public sealed class Bill : AggregateRoot<BillId>
{
    public Bill(BillId id,
                HostId hostId,
                GuestId guestId,
                DinnerId dinnerId,
                DateTime createdDateTime,
                DateTime updatedDateTime,
                Price price) : base(id)
    {
        HostId = hostId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        Price = price;
    }

    public Price Price { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public HostId HostId { get; set; }
    public GuestId GuestId { get; set; }
    public DinnerId DinnerId { get; set; }

    public static Bill Create(HostId hostId,
                GuestId guestId,
                DinnerId dinnerId,
                Price price)
    {
        return new Bill(BillId.CreateUnique(),
                        hostId,
                        guestId,
                        dinnerId,
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                        price);
    }  
}
