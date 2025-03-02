using TabletopConnect.Application.Extensions;
using TabletopConnect.Application.Persistence.Interfaces;
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

    public async Task<BoardGameDetailsReturnDto?> GetBoardGameDetails(
        int id, CancellationToken cancellationToken = default)
    {
        var details = await _boardGamesRepository.GetBoardGameDetailsAsync(id, cancellationToken);
        
        if (details is null)
            return null;

        return new BoardGameDetailsReturnDto(
            new BoardGameReturnDto(
                details.BoardGame.Id,
                details.BoardGame.Name,
                details.BoardGame.Description,
                details.BoardGame.YearPublished,
                details.BoardGame.GameComplexity,
                details.BoardGame.IsReimplementation,
                details.BoardGame.ImagePath,
                details.BoardGame.PlayTime.ManufacturerStatedPlayTime,
                details.BoardGame.PlayTime.CommunityMinPlayTime,
                details.BoardGame.PlayTime.CommunityMaxPlayTime,
                details.BoardGame.RecommendedAge.ManufacturerRecomended,
                details.BoardGame.RecommendedAge.CommunityRecomended,
                details.BoardGame.Players.MinPlayers,
                details.BoardGame.Players.MaxPlayers,
                details.BoardGame.Players.BestPlayers,
                details.BoardGame.Players.GoodPlayers,
                details.BoardGame.BggData?.BggId,
                details.BoardGame.BggData?.BggScore,
                details.BoardGame.BggData?.AverageRating,
                details.BoardGame.BggData?.RankOverall,
                details.BoardGame.LanguageDependence,
                details.BoardGame.LanguageDependence.GetDisplayName()),
            details.Categories.Select(
                c => new CategoryWithPositionReturnDto(
                    c.Position, new ClassifierReturnDto(c.Category.Id, c.Category.Name))).ToList(),
            details.Designers.Select(d => new ClassifierReturnDto(d.Id, d.Name)).ToList(),
            details.Mechanics.Select(m => new ClassifierReturnDto(m.Id, m.Name)).ToList(),
            details.Publishers.Select(p => new ClassifierReturnDto(p.Id, p.Name)).ToList(),
            details.Subcategories.Select(s => new ClassifierReturnDto(s.Id, s.Name)).ToList(),
            details.Themes.Select(t => new ClassifierReturnDto(t.Id, t.Name)).ToList(),
            details.Family is not null
                ? new ClassifierReturnDto(details.Family.Id, details.Family.Name) : null);
    }
}
