using MySpot.Services.Reservations.Core.Events;
using MySpot.Services.Reservations.Core.Types;
using MySpot.Services.Reservations.Core.ValueObjects;

namespace MySpot.Services.Reservations.Core.Entities;

public class WeeklyReservations : AggregateRoot
{
    private readonly HashSet<Reservation> _reservations = new();
    
    public JobTitle JobTitle { get; private set; }
    public UserId UserId { get; }
    public Week Week { get; }
    
    public IEnumerable<Reservation> Reservations { get; }

    public WeeklyReservations(AggregateId id, User user, Week week)
    {
        Id = id;
        UserId = user.Id;
        JobTitle = user.JobTitle;
        Week = week;
    }

    public void AddReservation(Reservation reservation, Date now)
    {
        // LOGIC
        _reservations.Add(reservation);
        AddEvent(new ReservationAdded(this, reservation));
    }

    public void ChangeReservationLicencePlate(ReservationId reservationId, LicensePlate licensePlate)
    {
        var reservation = _reservations.SingleOrDefault(x => x.Id == reservationId);
        reservation.ChangeLicensePlate(licensePlate);
        
    }
}