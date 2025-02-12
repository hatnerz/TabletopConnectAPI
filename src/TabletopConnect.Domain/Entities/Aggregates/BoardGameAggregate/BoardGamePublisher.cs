using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGamePublisher : Entity<int>
{
    public int GameId { get; private set; }
    public int PublisherId { get; private set; }

    public BoardGamePublisher(int gameId, int publisherId)
    {
        GameId = gameId;
        PublisherId = publisherId;
    }
}
