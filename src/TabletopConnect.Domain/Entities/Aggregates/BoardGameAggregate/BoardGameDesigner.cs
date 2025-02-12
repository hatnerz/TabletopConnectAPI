using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameDesigner : Entity<int>
{
    public int GameId { get; private set; }
    public int DesignerId { get; private set; }

    public BoardGameDesigner(int gameId, int designerId)
    {
        GameId = gameId;
        DesignerId = designerId;
    }
}
