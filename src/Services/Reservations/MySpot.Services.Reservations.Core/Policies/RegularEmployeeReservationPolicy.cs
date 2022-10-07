using Micro.Time;
using MySpot.Services.Reservations.Core.Entities;
using MySpot.Services.Reservations.Core.ValueObjects;

namespace MySpot.Services.Reservations.Core.Policies;

public sealed class RegularEmployeeReservationPolicy : IReservationPolicy
{
    private readonly IClock _clock;

    public RegularEmployeeReservationPolicy(IClock clock)
        => _clock = clock;

    public bool CanBeApplied(JobTitle jobTitle)
        => jobTitle == JobTitle.Employee;

    public bool CanReserve(IEnumerable<Reservation> reservations)
    {
        var totalEmployeeReservations = reservations.Count();
        return totalEmployeeReservations <= 3 && _clock.Current().Hour >= 10;
    }
}