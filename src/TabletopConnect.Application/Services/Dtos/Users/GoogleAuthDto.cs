namespace TabletopConnect.Application.Services.Dtos.Users;

public record GoogleAuthDto(
    string GoogleId,
    string Email,
    bool EmailVerified,
    string FirstName,
    string LastName,
    string? ProfilePictureUrl);