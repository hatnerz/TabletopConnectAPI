using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGameTheme : Entity<int>
{
    public int GameId { get; set; }
    public int ThemeId { get; set; }

    public BoardGameTheme(int gameId, int themeId)
    {
        GameId = gameId;
        ThemeId = themeId;
    }
}
