using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameSubcategory : Entity<int>
{
    public int GameId { get; set; }
    public int SubcategoryId { get; set; }

    public BoardGameSubcategory(int gameId, int subcategoryId)
    {
        GameId = gameId;
        SubcategoryId = subcategoryId;
    }
}
