using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameSubcategory : BoardGameRelatedClassifier<int>
{
    public int SubcategoryId { get; set; }

    private BoardGameSubcategory()
    {
    }

    public BoardGameSubcategory(int gameId, int subcategoryId) : base(gameId)
    {
        BoardGameId = gameId;
        SubcategoryId = subcategoryId;
    }
}
