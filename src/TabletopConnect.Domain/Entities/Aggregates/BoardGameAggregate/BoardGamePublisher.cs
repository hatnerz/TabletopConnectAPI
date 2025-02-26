using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGamePublisher : BoardGameRelatedClassifier<int>
{
    public int PublisherId { get; private set; }

    private BoardGamePublisher()
    {
    }

    public BoardGamePublisher(int gameId, int publisherId) : base(gameId)
    {
        BoardGameId = gameId;
        PublisherId = publisherId;
    }
}
