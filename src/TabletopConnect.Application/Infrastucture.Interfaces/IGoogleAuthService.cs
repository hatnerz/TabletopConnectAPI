using TabletopConnect.Application.Services.Dtos.Users;

namespace TabletopConnect.Application.Infrastucture.Interfaces;

public interface IGoogleAuthService
{
    Task<GoogleAuthDto?> ValidateGoogleTokenAsync(string token);
}