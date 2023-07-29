
using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.Dinner.Entities;
using BubberDinner.Domain.Dinner.Enums;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.Menu.ValueObjects;

namespace BubberDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
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
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DinnerStatus Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public HostId HostId { get; }
    public MenuId MenuId { get; }
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
