using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameTheme : BoardGameRelatedClassifier<int>
{
    public int ThemeId { get; set; }

    private BoardGameTheme()
    {
    }

    public BoardGameTheme(int gameId, int themeId) : base(gameId)
    {
        BoardGameId = gameId;
        ThemeId = themeId;
    }
}
