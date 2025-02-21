using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGamePublisher : Entity<int>
{
    public int BoardGameId { get; private set; }
    public int PublisherId { get; private set; }

    private BoardGamePublisher()
    {
    }

    public BoardGamePublisher(int gameId, int publisherId)
    {
        BoardGameId = gameId;
        PublisherId = publisherId;
    }
}
