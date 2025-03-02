namespace TabletopConnect.Infrastructure.Authentication;
public interface ICurrentUserService
{
    CurrentUserModel? GetCurrentUser();
}
