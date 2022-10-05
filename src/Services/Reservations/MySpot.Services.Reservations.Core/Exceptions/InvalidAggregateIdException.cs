using Micro.Exceptions;

namespace MySpot.Services.Reservations.Core.Exceptions;

public class InvalidAggregateIdException : CustomException
{
    public Guid Id { get; }

    public InvalidAggregateIdException(Guid id) : base($"Invalid aggregate id: {id}")
        => Id = id;
}