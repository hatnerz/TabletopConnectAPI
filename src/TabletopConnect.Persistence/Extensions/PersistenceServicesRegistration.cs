using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using TabletopConnect.Application.Infrastucture.Interfaces;
using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;
using TabletopConnect.Persistence.Database;
using TabletopConnect.Persistence.Repositories;

namespace TabletopConnect.Persistence.Extensions;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentException("Connection string not specified");

        services.AddDbContext<TabletopDbContext>(optionsBuilder =>
        {
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseSeeding((context, _) =>
                {
                    if (context.Set<BoardGame>().Any())
                        return;

                    var servicesProvider = services.BuildServiceProvider().CreateScope().ServiceProvider;

                    var importService = servicesProvider.GetService<IBoardGamesCsvImportService>() ?? throw new InvalidOperationException("BoardGamesCsvImportService not found.");

                    var basePath = AppContext.BaseDirectory;
                    var boardGamesPath = configuration["CsvFilePaths:BoardGames"] ?? "";
                    var pathResult = Path.Combine(basePath, boardGamesPath);

                    if (!File.Exists(pathResult))
                    {
                        throw new FileNotFoundException($"Board games CSV file not found. Path: {pathResult}");
                    }

                    using var boardGameFileStream = File.OpenRead(pathResult);
                    var gamesData = importService.GetBoardGamesInitialImportData(boardGameFileStream);

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
                                g.MinPlayers,
                                g.MaxPlayers,
                                g.BestPlayers,
                                Regex.Matches(g.GoodPlayers, @"\d+")
                                    .Select(m => int.Parse(m.Value))
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
   
                            if (!categoryDict.TryGetValue(gc.RelatedEntityName, out var categoryId))
                                return null;

                            return new BoardGameCategory(gameId, categoryId);
                        })
                        .Where(gc => gc != null)
                        .ToList();

                    //var message = string.Concat(
                    //    $"  Games: {string.Join("; ", games.Select(g => g.Id.ToString()).ToList())}",
                    //    $"  Categories: {string.Join("; ", categories.Select(c => c.Id.ToString()).ToList())}",
                    //    $"  GameCategories: {string.Join("; ", gameCategories.Select(gc => $"{gc!.BoardGameId} - {gc.CategoryId}"))}");

                    context.Set<BoardGameCategory>().AddRange(gameCategories!);
                    context.SaveChanges();
                });
        });


        services.AddScoped<IBoardGamesRepository, BoardGamesRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<IFamiliesRepository, FamiliesRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
