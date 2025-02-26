using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameDesigner : BoardGameRelatedClassifier<int>
{
    public int DesignerId { get; private set; }

    private BoardGameDesigner()
    {
    }

    public BoardGameDesigner(int gameId, int designerId) : base(gameId)
    {
        BoardGameId = gameId;
        DesignerId = designerId;
    }
}
