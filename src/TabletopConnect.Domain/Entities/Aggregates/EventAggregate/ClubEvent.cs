using TabletopConnect.Domain.Entities.Common.ValueObjects;

namespace TabletopConnect.Domain.Entities.Aggregates.EventAggregate;

public class ClubEvent : Event
{
    public int GameCLubId { get; private set; }

    public ClubEvent(
        int gameCLubId,
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
        GameCLubId = gameCLubId;
    }
}
