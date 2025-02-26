namespace TabletopConnect.Domain.Entities.Common;

public abstract class BoardGameRelatedClassifier<TKey> : Entity<TKey>
    where TKey : struct
{
    public int BoardGameId { get; protected set; }

    protected BoardGameRelatedClassifier()
    {
    }

    protected BoardGameRelatedClassifier(int boardGameId)
    {
        BoardGameId = boardGameId;
    }

}
