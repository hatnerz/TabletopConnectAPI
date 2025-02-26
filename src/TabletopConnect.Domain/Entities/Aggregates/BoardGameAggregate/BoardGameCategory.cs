using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Domain.Validators;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameCategory : BoardGameRelatedClassifier<int>
{
    public int CategoryId { get; private set; }
    public int? BggPosition { get; private set; }

    private BoardGameCategory()
    {
    }

    public BoardGameCategory(int gameId, int categoryId, int? position = null) : base(gameId)
    {
        NumberValidators.ValidateRangeInclusive(position, 0, null, nameof(BggPosition));

        CategoryId = categoryId;
        BggPosition = position;
    }
}
