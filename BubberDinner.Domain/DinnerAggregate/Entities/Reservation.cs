using BubberDinner.Domain.Bill.ValueObjects;
using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Dinner.Enums;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Guest.ValueObjects;

namespace BubberDinner.Domain.Dinner.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public Reservation(ReservationId id,
                       GuestId guestId,
                       BillId billId,
                       int guestCount,
                       ReservationStatus reservationStatus,
                       DateTime arrivedDateTime,
                       DateTime createdDateTime,
                       DateTime updatedDateTime) : base(id)
    {
        ArrivedDateTime = arrivedDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        GuestCount = guestCount;
    }

    public int GuestCount { get; private set; }
    public ReservationStatus ReservationStatus { get; private set; }
    public DateTime ArrivedDateTime { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public GuestId GuestId { get; private set; }
    public BillId BillId { get; private set; }

    public static Reservation Create(GuestId guestId, BillId billId, int guestCount, ReservationStatus reservationStatus)
    {
        return new(ReservationId.CreateUnique(),
                   guestId,
                   billId,
                   guestCount,
                   reservationStatus,
                   DateTime.UtcNow,
                   DateTime.UtcNow,
                   DateTime.UtcNow);
    }
}
