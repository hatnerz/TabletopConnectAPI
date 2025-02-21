using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameDesigner : Entity<int>
{
    public int BoardGameId { get; private set; }
    public int DesignerId { get; private set; }

    private BoardGameDesigner()
    {
    }

    public BoardGameDesigner(int gameId, int designerId)
    {
        BoardGameId = gameId;
        DesignerId = designerId;
    }
}
