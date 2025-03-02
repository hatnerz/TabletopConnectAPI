using TabletopConnect.Domain.Entities.IAM;

namespace TabletopConnect.Infrastructure.Authentication;

public record CurrentUserModel(
    int UserId,
    string Email,
    int PlayerProfileId,
    Role Role);