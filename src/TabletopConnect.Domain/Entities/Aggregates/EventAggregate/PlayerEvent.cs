using TabletopConnect.Domain.Entities.Common.ValueObjects;

namespace TabletopConnect.Domain.Entities.Aggregates.EventAggregate;

public class PlayerEvent : Event
{
    public int OrganizerPlayerId { get; private set; }

    public PlayerEvent(
        int organizerPlayerId,
        string name,
        string? description,
        int? maxPlayers,
        int? minPlayers,
        DateTime startDate,
        DateTime endDate,
        bool isOnline,
        Location location,
        EventType eventType,
        decimal? price,
        int? boardGameId)
            : base(name, description, maxPlayers, minPlayers, startDate, endDate, isOnline, location, eventType, price, boardGameId)
    {
        OrganizerPlayerId = organizerPlayerId;
    }
}
