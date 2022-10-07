using Micro.Time;
using MySpot.Services.Reservations.Core.Entities;
using MySpot.Services.Reservations.Core.Exception;
using MySpot.Services.Reservations.Core.Policies;
using MySpot.Services.Reservations.Core.Types;
using MySpot.Services.Reservations.Core.ValueObjects;

namespace MySpot.Services.Reservations.Core.DomainServices;

public sealed class WeeklyReservationsService : IWeeklyReservationsService
{
    private readonly IEnumerable<IReservationPolicy> _policies;
    private readonly IClock _clock;

    public WeeklyReservationsService(IEnumerable<IReservationPolicy> policies, IClock clock)
    {
        _policies = policies;
        _clock = clock;
    }

    public Reservation Reserve(WeeklyReservations currentWeekReservation, WeeklyReservations lastWeekReservations,
        ParkingSpotId parkingSpotId, Capacity capacity, LicensePlate licensePlate, Date date, string note = default)
    {
        if (lastWeekReservations is not null)
        {
            var hasAnyIncorrectReservations = lastWeekReservations
                .Reservations.Any(x => x.State == ReservationState.Incorrect);

            if (hasAnyIncorrectReservations)
            {
                throw new CannotMakeReservationException(parkingSpotId);
            }
        }

        var reservation = new Reservation(ReservationId.Create(), parkingSpotId, capacity, licensePlate, date, note);
        currentWeekReservation.AddReservation(reservation, _policies, new Date(_clock.Current().Date));

        return reservation;
    }
}