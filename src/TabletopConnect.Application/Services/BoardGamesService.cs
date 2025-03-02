using TabletopConnect.Application.Extensions;
using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Application.Persistence.Interfaces.Dtos.BoardGames;
using TabletopConnect.Application.Services.Dtos.BoardGames;
using TabletopConnect.Application.Services.Dtos.Classifiers;
using TabletopConnect.Application.Services.Interfaces;
using TabletopConnect.Common.Constants;

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
        var take = pagination.PageSize ?? PaginationDefault.PageSize;
        if (take > 100)
            take = 100;

        var skip = ((pagination.PageNumber ?? PaginationDefault.Page) - 1) * take;
        var (games, total) = await _boardGamesRepository.GetPagedBoardGamesAsync(
            pagination.Filter,
            pagination.Sorting,
            pagination.Search,
            take,
            skip,
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
                e.MinPlayers,
                e.MaxPlayers,
                e.MinPlayTime,
                e.MaxPlayTime,
                e.FamilyId,
                e.FamilyName,
                e.LanguageDependence,
                e.LanguageDependence.GetDisplayName(),
                e.Categories.Select(c => new ClassifierReturnDto(
                    c.Id,
                    c.Name)).ToList()))
                .ToList());
    }
}
