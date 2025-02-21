using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameMechanic : Entity<int>
{
    public int BoardGameId { get; private set; }
    public int MechanicId { get; private set; }

    private BoardGameMechanic()
    {
    }

    public BoardGameMechanic(int gameId, int mechanicId)
    {
        BoardGameId = gameId;
        MechanicId = mechanicId;
    }
}
