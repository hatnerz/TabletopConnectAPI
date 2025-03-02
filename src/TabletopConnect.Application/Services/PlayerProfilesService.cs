using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Application.Services.Interfaces;
using TabletopConnect.Domain.Entities.Aggregates.PlayerProfile;

namespace TabletopConnect.Application.Services;

public class PlayerProfilesService : IPlayerProfilesService
{
    private readonly IPlayerProfilesRepository _playerProfilesRepository;
    private readonly IBoardGamesRepository _boardGamesRepository;
    private readonly IFavouriteGamesRepository _favouriteGamesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PlayerProfilesService(
        IBoardGamesRepository boardGamesRepository,
        IPlayerProfilesRepository playerProfileRepository,
        IFavouriteGamesRepository favouriteGamesRepository,
        IUnitOfWork unitOfWork)
    {
        _boardGamesRepository = boardGamesRepository;
        _playerProfilesRepository = playerProfileRepository;
        _favouriteGamesRepository = favouriteGamesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> AddFavouriteGameAsync(int playerProfileId, int boardGameId, CancellationToken cancellation)
    {
        var existingPlayerProfile = await _playerProfilesRepository.GetByIdAsync(playerProfileId, cancellation);
        var existingBoardGame = await _boardGamesRepository.GetByIdAsync(boardGameId, cancellation);

        if (existingPlayerProfile == null || existingBoardGame == null)
            return false;

        var favouriteGame = new FavouriteGame(playerProfileId, boardGameId);
        _favouriteGamesRepository.Add(favouriteGame);
        return await _unitOfWork.SaveChangesAsync(cancellation);
    }

    public async Task<bool> RemoveFavouriteGameAsync(int playerProfileId, int boardGameId, CancellationToken cancellation)
    {
        var favouriteGame = await _favouriteGamesRepository.GetByPlayerAndGameIds(playerProfileId, boardGameId, cancellation);

        if (favouriteGame == null)
            return false;

        _favouriteGamesRepository.Remove(favouriteGame);
        return await _unitOfWork.SaveChangesAsync(cancellation);
    }
}
