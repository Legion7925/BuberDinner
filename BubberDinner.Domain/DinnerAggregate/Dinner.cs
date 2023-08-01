
using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.Dinner.Entities;
using BubberDinner.Domain.Dinner.Enums;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.MenuAggregate.ValueObjects;

namespace BubberDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId, Guid>
{

#pragma warning disable CS8618
    public Dinner()
    {
    }
#pragma warning restore CS8618

    public Dinner(DinnerId id,
                  string name,
                  string description,
                  DateTime startDateTime,
                  DateTime endDateTime,
                  DinnerStatus status,
                  bool isPublic,
                  int maxGuests,
                  Price price,
                  string imageUrl ,
                  Location location,
                  DateTime createdDateTime, 
                  DateTime updatedDateTime,
                  HostId hostId,
                  MenuId menuId) : base(id)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
        IsPublic = isPublic;    
        MaxGuests = maxGuests;
        Price = price;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        HostId = hostId;
        MenuId = menuId;
    }

    private readonly List<Reservation> _reservations = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DinnerStatus Status { get; private set; }
    public bool IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public Price Price { get; private set; }
    public string ImageUrl { get; private set; }
    public Location Location { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    public static Dinner Create(string name,
                  string description,
                  DateTime startDateTime,
                  DateTime endDateTime,
                  DinnerStatus status,
                  bool isPublic,
                  int maxGuests,
                  Price price,
                  string imageUrl,
                  Location location,
                  HostId hostId,
                  MenuId menuId)
    {
        return new Dinner(DinnerId.CreateUnique(),
                          name,
                          description,
                          startDateTime,
                          endDateTime,
                          status,
                          isPublic,
                          maxGuests,
                          price,
                          imageUrl,
                          location,
                          DateTime.UtcNow,
                          DateTime.UtcNow,
                          hostId,
                          menuId);
    }
}
