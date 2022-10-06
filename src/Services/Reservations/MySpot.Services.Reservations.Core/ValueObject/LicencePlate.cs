using MySpot.Services.Reservations.Core.Exceptions;

namespace MySpot.Services.Reservations.Core.ValueObject;

public record LicencePlate
{
    public string Value { get; }

    public LicencePlate(string value)
    {
        if (value is null || value.Length is < 4 or > 8)
        {
            throw new InvalidLicencePlateException(value);
        }
        
        Value = value;
    }

    public static implicit operator string(LicencePlate licencePlate)
        => licencePlate.Value;
    
    public static implicit operator LicencePlate(string value)
        => new(value);
}