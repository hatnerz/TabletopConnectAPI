namespace TabletopConnect.API.Controllers.Dtos.Auth;

public record AuthRequest(
    string Email,
    string Password);