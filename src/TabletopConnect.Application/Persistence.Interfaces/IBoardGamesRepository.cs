using TabletopConnect.Application.Persistence.Interfaces.Dtos.BoardGames;
using TabletopConnect.Common.Enums;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Persistence.Repositories.Common;

namespace TabletopConnect.Application.Persistence.Interfaces;

public interface IBoardGamesRepository : IRepository<BoardGame, int>
{
    public Task<BoardGameDetails?> GetBoardGameDetailsAsync(int id, CancellationToken cancellationToken = default);

    public Task<(List<BoardGameSummary>, int)> GetPagedBoardGamesAsync(
        BoardGamesFilterDto? filter,
        List<(string FieldName, SortingDirection Sorting)>? sorting,
        string? search,
        int take,
        int skip,
        CancellationToken cancellationToken= default);
}
