using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Domain.Validators;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameCategory : Entity<int>
{
    public int GameId { get; set; }
    public int CategoryId { get; set; }
    public int? Position { get; set; }

    public BoardGameCategory(int gameId, int categoryId, int? position = null)
    {
        NumberValidators.ValidateRangeInclusive(position, 0, null, nameof(Position));

        GameId = gameId;
        CategoryId = categoryId;
        Position = position;
    }
}
