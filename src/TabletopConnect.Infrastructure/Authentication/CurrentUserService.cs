using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TabletopConnect.Domain.Entities.IAM;

namespace TabletopConnect.Infrastructure.Authentication;

internal class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public CurrentUserModel? GetCurrentUser()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null || !user.Identity?.IsAuthenticated == true)
            return null;

        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var emailClaim = user.FindFirst(ClaimTypes.Email)?.Value;
        var playerProfileIdClaim = user.FindFirst("PlayerProfileId")?.Value;
        var roleClaim = user.FindFirst(ClaimTypes.Role)?.Value;

        if (int.TryParse(userIdClaim, out var userId) &&
            int.TryParse(playerProfileIdClaim, out var playerProfileId))
        {
            Role role;
            int roleInt;
            if (!int.TryParse(roleClaim, out roleInt) && !Enum.IsDefined(typeof(Role), roleInt))
                return null;

            role = (Role)roleInt;

            return new CurrentUserModel(
                userId,
                emailClaim ?? string.Empty,
                playerProfileId,
                role);
        }

        return null;
    }
}