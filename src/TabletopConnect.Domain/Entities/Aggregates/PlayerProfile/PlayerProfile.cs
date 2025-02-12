using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.PlayerProfile;

public class PlayerProfile : Entity<int>
{
    public int UserId { get; set; }
    public string Nickname { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Bio { get; set; }

    public PlayerProfile(int userId, string nickname, string bio, string? avatarUrl = null)
    {
        UserId = userId;
        Nickname = nickname;
        Bio = bio;
        AvatarUrl = avatarUrl;
    }
}
