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
            query = query.Where(g => filter.ThemeIds == null || !filter.ThemeIds.Any() || g.BoardGameThemes.Any(bgt => filter.ThemeIds.Contains(bgt.ThemeId)));
            query = query.Where(g => filter.MechanicsIds == null || !filter.MechanicsIds.Any() || g.BoardGameMechanics.Any(bgm => filter.MechanicsIds.Contains(bgm.MechanicId)));
            query = query.Where(g => filter.FamiliesIds == null || !filter.FamiliesIds.Any() || (g.FamilyId != null && filter.FamiliesIds.Contains(g.FamilyId.Value)));
            query = query.Where(g => filter.LanguageDependence == null || g.LanguageDependence == filter.LanguageDependence);
            query = query.Where(g => filter.MinPlayTime == null || ((g.PlayTime.CommunityMinPlayTime ?? g.PlayTime.ManufacturerStatedPlayTime) <= filter.MinPlayTime));
            query = query.Where(g => filter.MaxPlayTime == null || ((g.PlayTime.CommunityMaxPlayTime ?? g.PlayTime.ManufacturerStatedPlayTime) >= filter.MaxPlayTime));
            query = query.Where(g => filter.Players == null || g.Players.MinPlayers <= filter.Players && g.Players.MaxPlayers >= filter.Players);
        }

        var groupedQuery =
            from game in query
            join family in _context.Set<Family>()
                on game.FamilyId equals family.Id into families
            from family in families.DefaultIfEmpty()
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
                game.Players.MinPlayers,
                game.Players.MaxPlayers,
                game.GameComplexity,
                game.LanguageDependence,
                MinPlayTime = game.PlayTime.CommunityMinPlayTime ?? game.PlayTime.ManufacturerStatedPlayTime, 
                MaxPlayTime = game.PlayTime.CommunityMaxPlayTime ?? game.PlayTime.ManufacturerStatedPlayTime,
                FamilyId = (int?)family.Id,
                FamilyName = (string?)family.Name,
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
                grouped.Key.MinPlayers,
                grouped.Key.MaxPlayers,
                grouped.Key.GameComplexity,
                grouped.Key.LanguageDependence,
                grouped.Key.MinPlayTime,
                grouped.Key.MaxPlayTime,
                grouped.Key.FamilyId,
                grouped.Key.FamilyName,
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
                e.MinPlayers,
                e.MaxPlayers,
                e.MinPlayTime,
                e.MaxPlayTime,
                e.FamilyId,
                e.FamilyName,
                e.LanguageDependence,
                e.Categories.ToList()))
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

        var totalCount = await groupedQuery.CountAsync(cancellationToken);

        return (items, totalCount);
    }
}
