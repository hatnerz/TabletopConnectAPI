using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Aggregates.PlayerProfile;

public class PlayerProfile : Entity<int>
{
    public int UserId { get; set; }
    public string? FirstName { get; private set; } = null!;
    public string? LastName { get; private set; } = null!;
    public string? Nickname { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Bio { get; set; }

    private PlayerProfile()
    {
    }

    public PlayerProfile(
        int userId,
        string? firstName = null,
        string? lastName = null,
        string? nickname = null,
        string? bio = null,
        string? avatarUrl = null)
    {
        FirstName = firstName;
        LastName = lastName;
        UserId = userId;
        Nickname = nickname;
        Bio = bio;
        AvatarUrl = avatarUrl;
    }

    public void UpdateIfNotNull(
        string? firstName = null,
        string? lastName = null,
        string? nickname = null,
        string? bio = null,
        string? avatarUrl = null)
    {
        FirstName = FirstName ?? firstName;
        LastName = LastName ?? lastName;
        Nickname = Nickname ?? nickname;
        Bio = Bio ?? bio;
        AvatarUrl = AvatarUrl ?? avatarUrl;
    }
}
