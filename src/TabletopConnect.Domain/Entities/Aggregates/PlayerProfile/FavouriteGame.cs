using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.PlayerProfile;

public class FavouriteGame : Entity<int>
{
    public int PlayerProfileId { get; set; }
    public int BoardGameId { get; set; }

    public FavouriteGame(int playerProfileId, int boardGameId)
    {
        PlayerProfileId = playerProfileId;
        BoardGameId = boardGameId;
    }
}
