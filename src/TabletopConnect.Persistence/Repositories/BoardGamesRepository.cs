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

    public Task<BoardGameDetails?> GetBoardGameDetailsAsync(
        int id, CancellationToken cancellationToken = default)
    {
        var query =
            from game in _context.Set<BoardGame>()
            where game.Id == id && !game.IsDeleted
            join bgc in _context.Set<BoardGameCategory>()
                on game.Id equals bgc.BoardGameId into gameCategories
            from bgc in gameCategories.DefaultIfEmpty()

            join category in _context.Set<Category>()
                on bgc.CategoryId equals category.Id into categories
            from category in categories.DefaultIfEmpty()

            join bgd in _context.Set<BoardGameDesigner>()
                on game.Id equals bgd.BoardGameId into gameDesigners
            from bgd in gameDesigners.DefaultIfEmpty()
            join designer in _context.Set<Designer>()
                on bgd.DesignerId equals designer.Id into designers
            from designer in designers.DefaultIfEmpty()

            join bgm in _context.Set<BoardGameMechanics>()
                on game.Id equals bgm.BoardGameId into gameMechanics
            from bgm in gameMechanics.DefaultIfEmpty()
            join mechanic in _context.Set<Mechanics>()
                on bgm.MechanicsId equals mechanic.Id into mechanics
            from mechanic in mechanics.DefaultIfEmpty()

            join bgp in _context.Set<BoardGamePublisher>()
                on game.Id equals bgp.BoardGameId into gamePublishers
            from bgp in gamePublishers.DefaultIfEmpty()
            join publisher in _context.Set<Publisher>()
                on bgp.PublisherId equals publisher.Id into publishers
            from publisher in publishers.DefaultIfEmpty()

            join bgs in _context.Set<BoardGameSubcategory>()
                on game.Id equals bgs.BoardGameId into gameSubcategories
            from bgs in gameSubcategories.DefaultIfEmpty()
            join subcategory in _context.Set<Subcategory>()
                on bgs.SubcategoryId equals subcategory.Id into subcategories
            from subcategory in subcategories.DefaultIfEmpty()

            join bgt in _context.Set<BoardGameTheme>()
                on game.Id equals bgt.BoardGameId into gameThemes
            from bgt in gameThemes.DefaultIfEmpty()
            join theme in _context.Set<Theme>()
                on bgt.ThemeId equals theme.Id into themes
            from theme in themes.DefaultIfEmpty()

            join family in _context.Set<Family>()
                on game.FamilyId equals family.Id into families
            from family in families.DefaultIfEmpty()

            group new { game, category, designer, mechanic, publisher, subcategory, theme, family, bgc }
            by game.Id into g

            select new BoardGameDetails(
                g.First().game,
                g.Where(x => x.category != null)
                 .Select(x => new CategoryWithPosition(x.bgc.BggPosition, x.category)).Distinct().ToList(),
                g.Where(x => x.designer != null)
                 .Select(x => x.designer).Distinct().ToList(),
                g.Where(x => x.mechanic != null)
                 .Select(x => x.mechanic).Distinct().ToList(),
                g.Where(x => x.publisher != null)
                 .Select(x => x.publisher).Distinct().ToList(),
                g.Where(x => x.subcategory != null)
                 .Select(x => x.subcategory).Distinct().ToList(),
                g.Where(x => x.theme != null)
                 .Select(x => x.theme).Distinct().ToList(),
                g.First().family
            );

        return query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<(List<BoardGameSummary>, int)> GetPagedBoardGamesAsync(
        BoardGamesFilterDto? filter,
        List<(string FieldName, SortingDirection Sorting)>? sorting,
        string? search,
        int take,
        int skip,
        CancellationToken cancellationToken = default)
    {
        var query = _set.Where(g => !g.IsDeleted);

        if (filter is not null)
        {
            query = query.Where(g => filter.CategoryIds == null || !filter.CategoryIds.Any() || g.BoardGameCategories.Any(bgc => filter.CategoryIds.Contains(bgc.CategoryId)));
            query = query.Where(g => filter.ThemeIds == null || !filter.ThemeIds.Any() || g.BoardGameThemes.Any(bgt => filter.ThemeIds.Contains(bgt.ThemeId)));
            query = query.Where(g => filter.MechanicsIds == null || !filter.MechanicsIds.Any() || g.BoardGameMechanics.Any(bgm => filter.MechanicsIds.Contains(bgm.MechanicsId)));
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
                BggScore = (double?)(game.BggData != null ? game.BggData!.BggScore : null)
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
