using Microsoft.EntityFrameworkCore;
using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Application.Persistence.Interfaces.Dtos.BoardGames;
using TabletopConnect.Common.Enums;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;
using TabletopConnect.Persistence.Database;
using TabletopConnect.Persistence.Extensions;

namespace TabletopConnect.Persistence.Repositories;

internal class BoardGamesRepository : Repository<BoardGame, int>, IBoardGamesRepository
{
    public BoardGamesRepository(TabletopDbContext context) : base(context)
    {
    }

    public Task<BoardGameDetails> GetBoardGameDetailsAsync(
        int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<(List<BoardGameSummary>, int)> GetPagedBoardGamesAsync(
        BoardGamesFilterDto? filter,
        List<(string FieldName, SortingDirection Sorting)>? sorting,
        string? search,
        int take,
        int skip,
        CancellationToken cancellationToken = default)
    {
        var query = _set.AsQueryable();

        if (filter is not null)
        {
            query = query.Where(g => filter.CategoryIds == null || !filter.CategoryIds.Any() || g.BoardGameCategories.Any(bgc => filter.CategoryIds.Contains(bgc.CategoryId)));
        }

        var groupedQuery =
            from game in query
            join bgc in _context.Set<BoardGameCategory>()
                on game.Id equals bgc.BoardGameId into gameCategories
            from bgc in gameCategories.DefaultIfEmpty()
            join category in _context.Set<Category>()
                on bgc.CategoryId equals category.Id into categories
            from category in categories.DefaultIfEmpty()
            group category by new
            {
                game.Id,
                game.Name,
                game.Description,
                game.YearPublished,
                game.ImagePath,
                BggRank = (int?)(game.BggData != null ? game.BggData!.RankOverall : null),
                BggScore = (double?)(game.BggData != null ? game.BggData!.AverageRating : null)
            }
            into grouped
            select new
            {
                grouped.Key.Id,
                grouped.Key.Name,
                grouped.Key.Description,
                grouped.Key.YearPublished,
                grouped.Key.ImagePath,
                grouped.Key.BggRank,
                grouped.Key.BggScore,
                Categories = grouped.Where(c => c != null).ToList()
            };

        if (sorting is not null)
        {
            groupedQuery = groupedQuery.ApplySorting(sorting);
        }

        if(!string.IsNullOrWhiteSpace(search))
        {
            groupedQuery = groupedQuery.Where(g => EF.Functions.Like(g.Name, $"%{search.ToLower()}%"));
        }

        var items = await groupedQuery
            .Select(e => new BoardGameSummary(
                e.Id,
                e.Name,
                e.Description,
                e.YearPublished,
                e.BggRank,
                e.BggScore,
                e.ImagePath,
                e.Categories.ToList()))
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

        var totalCount = await groupedQuery.CountAsync(cancellationToken);

        return (items, totalCount);
    }
}
