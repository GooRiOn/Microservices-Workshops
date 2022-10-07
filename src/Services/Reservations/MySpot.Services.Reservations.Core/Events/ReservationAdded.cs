using MySpot.Services.Reservations.Core.Entities;

namespace MySpot.Services.Reservations.Core.Events;

public record ReservationAdded(WeeklyReservations WeeklyReservations, Reservation Reservation) : IDomainEvent;
