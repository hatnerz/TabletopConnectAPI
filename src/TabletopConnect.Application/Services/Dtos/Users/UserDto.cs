using TabletopConnect.Domain.Entities.IAM;

namespace TabletopConnect.Application.Services.Dtos.Users;

public record UserDto(
    int Id,
    string Email,
    string? PhoneNumber,
    string? GoogleId,
    Role Role);