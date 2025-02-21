using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameTheme : Entity<int>
{
    public int BoardGameId { get; set; }
    public int ThemeId { get; set; }

    private BoardGameTheme()
    {
    }

    public BoardGameTheme(int gameId, int themeId)
    {
        BoardGameId = gameId;
        ThemeId = themeId;
    }
}
