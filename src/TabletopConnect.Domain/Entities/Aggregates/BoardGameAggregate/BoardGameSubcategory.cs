using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameSubcategory : Entity<int>
{
    public int BoardGameId { get; set; }
    public int SubcategoryId { get; set; }

    private BoardGameSubcategory()
    {
    }

    public BoardGameSubcategory(int gameId, int subcategoryId)
    {
        BoardGameId = gameId;
        SubcategoryId = subcategoryId;
    }
}
