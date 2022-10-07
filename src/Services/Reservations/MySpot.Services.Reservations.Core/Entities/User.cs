using MySpot.Services.Reservations.Core.Types;
using MySpot.Services.Reservations.Core.ValueObjects;

namespace MySpot.Services.Reservations.Core.Entities;

public class User
{
    public UserId Id { get; private set; }
    public JobTitle JobTitle { get; private set; }

    public User(UserId userId, JobTitle jobTitle)
    {
        Id = userId;
        JobTitle = jobTitle;
    }

    public void ChangeJobTitle(JobTitle jobTitle)
        => JobTitle = jobTitle;
}