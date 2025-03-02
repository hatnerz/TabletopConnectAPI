using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameMechanics : BoardGameRelatedClassifier<int>
{
    public int MechanicsId { get; private set; }

    private BoardGameMechanics()
    {
    }

    public BoardGameMechanics(int gameId, int mechanicId) : base(gameId)
    {
        BoardGameId = gameId;
        MechanicsId = mechanicId;
    }
}
