namespace TabletopConnect.Application.Services.Interfaces;

public interface IPlayerProfilesService
{
    Task<bool> AddFavouriteGameAsync(int playerProfileId, int boardGameId, CancellationToken cancellation);
    Task<bool> RemoveFavouriteGameAsync(int playerProfileId, int boardGameId, CancellationToken cancellation);
}