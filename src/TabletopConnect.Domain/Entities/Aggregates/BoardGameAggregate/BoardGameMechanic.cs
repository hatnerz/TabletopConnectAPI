using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameMechanic : Entity<int>
{
    public int GameId { get; private set; }
    public int MechanicId { get; private set; }

    public BoardGameMechanic(int gameId, int mechanicId)
    {
        GameId = gameId;
        MechanicId = mechanicId;
    }
}
