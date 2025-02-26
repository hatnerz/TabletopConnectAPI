using Google.Apis.Auth;
using TabletopConnect.Application.Infrastucture.Interfaces;
using TabletopConnect.Application.Services.Dtos.Users;

namespace TabletopConnect.Infrastructure.Authentication;

internal class GoogleAuthService : IGoogleAuthService
{
    public async Task<GoogleAuthDto?> ValidateGoogleTokenAsync(string token)
    {
        try
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(token);
            return new GoogleAuthDto(
                payload.Subject,
                payload.Email,
                payload.EmailVerified,
                payload.GivenName,
                payload.FamilyName,
                payload.Picture);
        }
        catch(InvalidJwtException)
        {
            return null;
        }

    }
}
