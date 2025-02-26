namespace TabletopConnect.Application.Services.Dtos.Users;

public record LinkGoogleDto(
    int UserId,
    string GoogleToken);
