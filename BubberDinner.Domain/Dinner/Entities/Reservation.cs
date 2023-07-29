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

    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; }
    public DateTime ArrivedDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public GuestId GuestId { get; }
    public BillId BillId { get; }

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
