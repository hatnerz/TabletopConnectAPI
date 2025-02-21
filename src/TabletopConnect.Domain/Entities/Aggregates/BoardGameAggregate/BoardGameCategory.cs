using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Domain.Validators;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameCategory : Entity<int>
{
    public int BoardGameId { get; set; }
    public int CategoryId { get; set; }
    public int? BggPosition { get; set; }

    private BoardGameCategory()
    {
    }

    public BoardGameCategory(int gameId, int categoryId, int? position = null)
    {
        NumberValidators.ValidateRangeInclusive(position, 0, null, nameof(BggPosition));

        BoardGameId = gameId;
        CategoryId = categoryId;
        BggPosition = position;
    }
}
