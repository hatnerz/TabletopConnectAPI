using TabletopConnect.Application.Services.Dtos.Users;
using TabletopConnect.Application.Services.Validation;

namespace TabletopConnect.Application.Services.Interfaces;

public interface IUsersService
{
    Task<AuthResultDto> AuthenticateAsync(AuthDto dto, CancellationToken cancellationToken);

    Task<AuthResultDto> AuthenticateWithGoogleAsync(string token, CancellationToken cancellationToken);

    Task<ValidationResultDto> LinkGoogleAccountAsync(LinkGoogleDto dto, CancellationToken cancellationToken);

    Task<ValidationResultDto> RegisterAsync(AuthDto dto, CancellationToken cancellationToken);
}