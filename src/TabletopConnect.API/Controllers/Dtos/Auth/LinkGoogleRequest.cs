namespace TabletopConnect.API.Controllers.Dtos.Auth;

public record LinkGoogleRequest(
    int UserId,
    string GoogleToken);
