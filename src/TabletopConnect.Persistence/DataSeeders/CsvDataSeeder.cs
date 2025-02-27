using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using TabletopConnect.Application.Infrastucture.Interfaces;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;
using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Persistence.DataSeeders;

public class CsvDataSeeder
{
    private readonly IConfiguration configuration;
    private readonly IBoardGamesCsvImportService importService;
    private readonly DbContext context;
    private readonly string basePath;

    public CsvDataSeeder(IConfiguration configuration, IBoardGamesCsvImportService importService, DbContext context)
    {
        this.context = context;
        this.configuration = configuration;
        this.importService = importService;
        basePath = AppContext.BaseDirectory;
    }

    public void SeedBoardGameWithCategories()
    {
        if (context.Set<BoardGame>().Any())
            return;

        var boardGamesPath = configuration["CsvFilePaths:BoardGames"] ?? "";
        var pathResult = Path.Combine(basePath, boardGamesPath);

        if (!File.Exists(pathResult))
        {
            throw new FileNotFoundException($"Board games CSV file not found. Path: {pathResult}");
        }

        using var boardGameFileStream = File.OpenRead(pathResult);
        var gamesData = importService.GetBoardGamesImportedData(boardGameFileStream);

        var categories = gamesData.Categories
            .Select(c => new Category(c.Name))
            .ToList();

        context.Set<Category>().AddRange(categories);
        context.SaveChanges();

        var families = gamesData.Families
            .Select(f => new Family(f.Name))
            .ToList();

        context.Set<Family>().AddRange(families);
        context.SaveChanges();

        var games = gamesData.BoardGames
            .Select(g => new BoardGame(
                g.Name,
                g.Description,
                g.YearPublished,
                g.GameWeight,
                g.IsReimplementation,
                g.ImagePath,
                new PlayTime(
                    g.MfgPlayTime,
                    g.ComMinPlaytime,
                    g.ComMaxPlaytime),
                new RecommendedAge(
                    g.MfgAgeRec,
                    g.ComAgeRec),
                new Players(
                    g.MinPlayers != 0 ? g.MinPlayers : 1,
                    g.MaxPlayers != 0 ? g.MaxPlayers : 1,
                    g.BestPlayers != 0 ? g.BestPlayers : (g.MinPlayers != 0 ? g.MinPlayers : 1),
                    Regex.Matches(g.GoodPlayers, @"\d+")
                        .Select(m => int.Parse(m.Value))
                        .Where(m => m != 0)
                        .Distinct()
                        .ToList()),
                new BggData(
                    g.BggId,
                    g.BayesAvgRating,
                    g.NumOwned,
                    g.NumWant,
                    g.NumWish,
                    g.NumWeightVotes,
                    g.AvgRating,
                    g.OverallRank),
                g.LanguageEase ?? LanguageDependence.Unknown,
                null,
                families.FirstOrDefault(f => g.FamilyName == f.Name)?.Id))
            .ToList();

        context.Set<BoardGame>().AddRange(games);
        context.SaveChanges();

        var gameDict = games
            .Where(g => g.BggData != null)
            .ToDictionary(g => g.BggData!.BggId, g => g.Id);

        var categoryDict = categories
            .ToDictionary(c => c.Name, c => c.Id);

        var gameCategories = gamesData.BoardGameCategories
            .Select(gc =>
            {
                if (!gameDict.TryGetValue(gc.BggId, out var gameId))
                    return null;

                if (!categoryDict.TryGetValue(gc.BoardGameCategoryName, out var categoryId))
                    return null;

                return new BoardGameCategory(gameId, categoryId, gc.Rank);
            })
            .Where(gc => gc != null)
            .ToList();

        //var message = string.Concat(
        //    $"  Games: {string.Join("; ", games.Select(g => g.Id.ToString()).ToList())}",
        //    $"  Categories: {string.Join("; ", categories.Select(c => c.Id.ToString()).ToList())}",
        //    $"  GameCategories: {string.Join("; ", gameCategories.Select(gc => $"{gc!.BoardGameId} - {gc.CategoryId}"))}");

        context.Set<BoardGameCategory>().AddRange(gameCategories!);
        context.SaveChanges();
    }

    public void SeedSubcategories()
    {
        var subcategoriesPath = configuration["CsvFilePaths:Subcategories"] ?? "";
        var pathResult = Path.Combine(basePath, subcategoriesPath);

        SeedClassifierDefault<Subcategory, BoardGameSubcategory>(pathResult);
    }

    public void SeedDesigners()
    {
        var designersPath = configuration["CsvFilePaths:Designers"] ?? "";
        var pathResult = Path.Combine(basePath, designersPath);

        SeedClassifierDefault<Designer, BoardGameDesigner>(pathResult);
    }

    public void SeedMechanics()
    {
        var mechanicsPath = configuration["CsvFilePaths:Mechanics"] ?? "";
        var pathResult = Path.Combine(basePath, mechanicsPath);

        SeedClassifierDefault<Mechanics, BoardGameMechanic>(pathResult);
    }

    public void SeedPublishers()
    {
        var publishersPath = configuration["CsvFilePaths:Publishers"] ?? "";
        var pathResult = Path.Combine(basePath, publishersPath);

        SeedClassifierDefault<Publisher, BoardGamePublisher>(pathResult);
    }

    public void SeedThemes()
    {
        if (context.Set<Theme>().Any())
            return;

        var themesPath = configuration["CsvFilePaths:Themes"] ?? "";
        var pathResult = Path.Combine(basePath, themesPath);

        if (!File.Exists(pathResult))
        {
            throw new FileNotFoundException($"Themes CSV file not found. Path: {pathResult}");
        }

        using var themesFileStream = File.OpenRead(pathResult);
        var themesData = importService.GetThemesImportedData(themesFileStream);

        var themes = themesData.Classifiers
            .Select(p => new Theme(p.Name))
            .ToList();

        context.Set<Theme>().AddRange(themes);
        context.SaveChanges();

        var games = context.Set<BoardGame>()
            .Where(e => e.BggData != null)
            .ToDictionary(e => e.BggData!.BggId, e => e.Id);

        var themesDict = themes
            .ToDictionary(e => e.Name, e => e.Id);

        var gameThemes = themesData.BoardGameWithClassfierRelations
            .Select(e =>
            {
                if (!games.TryGetValue(e.BggId, out var gameId))
                    return null;

                if (!themesDict.TryGetValue(e.RelatedEntityName, out var themeId))
                    return null;

                return new BoardGameTheme(gameId, themeId);
            })
            .Where(e => e != null)
            .ToList();

        context.Set<BoardGameTheme>().AddRange(gameThemes!);
        context.SaveChanges();
    }

    private void SeedClassifierDefault<TClassifier, TRelatedClassifier>(
        string filePath)
        where TClassifier : BaseClassifier<int>
        where TRelatedClassifier : BoardGameRelatedClassifier<int>
    {
        if (context.Set<TClassifier>().Any())
            return;

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"{typeof(TClassifier).Name} CSV file not found. Path: {filePath}");
        }

        using var fileStream = File.OpenRead(filePath);
        var classifiersData = importService.GetClassifiersWithRelationsImportedDataDefault(fileStream);

        var classifiers = classifiersData.Classifiers
            .Select(c => (TClassifier?)Activator.CreateInstance(typeof(TClassifier), c.Name))
            .Where(c => c != null)
            .ToList();

        context.Set<TClassifier>().AddRange(classifiers!);
        context.SaveChanges();

        var games = context.Set<BoardGame>()
            .Where(g => g.BggData != null)
            .ToDictionary(g => g.BggData!.BggId, g => g.Id);

        var classifiersDict = classifiers
            .ToDictionary(p => p.Name, p => p.Id);

        var relatedClassifiers = classifiersData.BoardGameWithClassfierRelations
            .Select(gp =>
            {
                if (!games.TryGetValue(gp.BggId, out var gameId))
                    return null;

                if (!classifiersDict.TryGetValue(gp.RelatedEntityName, out var relatedEntityId))
                    return null;

                return (TRelatedClassifier?)Activator.CreateInstance(typeof(TRelatedClassifier), gameId, relatedEntityId);
            })
            .Where(rc => rc != null)
            .ToList();

        context.Set<TRelatedClassifier>().AddRange(relatedClassifiers!);
        context.SaveChanges();
    }

}
