using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.EventAggregate;

public class EventParticipation : Entity<int>
{
    public int EventId { get; private set; }
    public int UserId { get; private set; }

    public DateTime RegistrationDate { get; private set; }

    public EventParticipation(int eventId, int userId, DateTime registrationDate)
    {
        EventId = eventId;
        UserId = userId;
        RegistrationDate = registrationDate;
    }
}
