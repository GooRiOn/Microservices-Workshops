using MySpot.Services.Reservations.Core.Exceptions;
using MySpot.Services.Reservations.Core.ValueObject;

namespace MySpot.Services.Reservations.Core.Entities;

public class Reservation
{
    public Guid Id { get; private set; }
    public Guid ParkingSpotId { get; private set; }
    public int Capacity { get; private set; }
    public LicencePlate LicencePlate { get; private set; }
    public DateTimeOffset Date { get; private set; }
    public string Note { get; private set; }
    public string State { get; private set; }

    public Reservation(Guid id, Guid parkingSpotId, int capacity, string licencePlate,
        DateTimeOffset date, string state, string note = null)
    {
        Id = id;
        ParkingSpotId = parkingSpotId;
        Capacity = capacity;
        LicencePlate = licencePlate;
        Date = date;
        State = state;
        Note = note;
    }

    public void ChangeLicencePlate(LicencePlate licencePlate)
        => LicencePlate = licencePlate;

    public void MarkAsValid()
    {
        if (State is "INVALID")
        {
            
        }
        State = "VALID";
    }

    public void MarkAsInvalid()
    {
        
    }
}