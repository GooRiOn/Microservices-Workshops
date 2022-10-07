using MySpot.Services.Reservations.Core.Entities;
using MySpot.Services.Reservations.Core.ValueObjects;

namespace MySpot.Services.Reservations.Core.Policies;

public sealed class ManagerReservationPolicy : IReservationPolicy
{
    public bool CanBeApplied(JobTitle jobTitle)
        => jobTitle == JobTitle.Manager;

    public bool CanReserve(IEnumerable<Reservation> reservations)
        => reservations.Count() <= 4;
}