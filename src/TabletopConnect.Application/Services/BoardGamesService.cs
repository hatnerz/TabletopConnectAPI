using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Application.Persistence.Interfaces.Dtos.BoardGames;
using TabletopConnect.Application.Services.Dtos.BoardGames;
using TabletopConnect.Application.Services.Dtos.Classifiers;
using TabletopConnect.Application.Services.Interfaces;

namespace TabletopConnect.Application.Services;


public class BoardGamesService : IBoardGamesService
{
    private readonly IBoardGamesRepository _boardGamesRepository;

    public BoardGamesService(IBoardGamesRepository boardGamesRepository)
    {
        _boardGamesRepository = boardGamesRepository;
    }

    public async Task<BoardGamesPaginationReturnDto> GetBoardGamesSummaryAsync(
        BoardGamesPaginationDto pagination, CancellationToken cancellationToken = default)
    {
        var (games, total) = await _boardGamesRepository.GetPagedBoardGamesAsync(
            pagination.Filter,
            pagination.Sorting,
            pagination.Search,
            pagination.PageSize,
            (pagination.PageNumber - 1) * pagination.PageSize,
            cancellationToken);

        return new(
            total,
            games.Select(e => new BoardGameSummaryReturnDto(
                e.Id,
                e.Name,
                e.Description,
                e.YearPublished,
                e.BggRank,
                e.BggScore,
                e.ImageUrl,
                e.Categories.Select(c => new ClassifierReturnDto(
                    c.Id,
                    c.Name)).ToList()))
                .ToList());
    }
}
