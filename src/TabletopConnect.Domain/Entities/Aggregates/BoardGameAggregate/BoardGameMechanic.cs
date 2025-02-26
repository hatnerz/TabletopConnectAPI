using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameMechanic : BoardGameRelatedClassifier<int>
{
    public int MechanicId { get; private set; }

    private BoardGameMechanic()
    {
    }

    public BoardGameMechanic(int gameId, int mechanicId) : base(gameId)
    {
        BoardGameId = gameId;
        MechanicId = mechanicId;
    }
}
