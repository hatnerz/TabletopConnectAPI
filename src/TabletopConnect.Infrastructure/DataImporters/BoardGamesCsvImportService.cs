using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
using System.Reflection;
using TabletopConnect.Application.Infrastucture.Interfaces;
using TabletopConnect.Application.Infrastucture.Interfaces.Dtos;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Infrastructure.DataImporters.Dtos;

namespace TabletopConnect.Infrastructure.DataImporters;

internal class BoardGamesCsvImportService : IBoardGamesCsvImportService
{
    public BoardGamesCsvResultDto GetBoardGamesInitialImportData(Stream csvStream)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            MissingFieldFound = null
        };

        csvStream.Position = 0;
        if (csvStream == null || csvStream.Length == 0)
            throw new ArgumentException("CSV stream is empty.", nameof(csvStream));


        using var reader = new StreamReader(csvStream);
        using var csv = new CsvReader(reader, config);
        var records = new List<BoardGameCsvInputDto>();

        var categoriesProperties = typeof(BoardGameCsvInputDto)
            .GetProperties()
            .Where(prop => {
                var attribute = prop.GetCustomAttribute<NameAttribute>();
                return attribute != null && attribute.Names.Any(n => n.StartsWith("Cat:", StringComparison.OrdinalIgnoreCase));
            })
            .ToList();

        csv.Read();

        if (!csv.ReadHeader() || csv.HeaderRecord == null)
            throw new InvalidOperationException("CSV header is null.");

        var categories = GetCategoriesFromImportedData(csv.HeaderRecord!);

        foreach (var record in csv.GetRecords<BoardGameCsvInputDto>())
        {
            records.Add(record);
        }

        var families = records
            .Select(r => r.Family)
            .Distinct()
            .Where(f => !string.IsNullOrEmpty(f))
            .Select(f => new ClassifierCsvReturnDto(f!))
            .ToList();

        var boardGames = records.Select(r => new BoardGameCsvReturnDto(
            r.BggId,
            r.Name,
            r.Description,
            r.YearPublished,
            r.GameWeight <= 1 ? 1 : r.GameWeight,
            r.BayesAvgRating,
            r.AvgRating,
            r.MinPlayers,
            r.MaxPlayers,
            r.ComAgeRec is not null? (int)Math.Round(r.ComAgeRec.Value) : null,
            r.LanguageEase.HasValue &&
                (int)Math.Round(r.LanguageEase.Value) >= 1 &&
                (int)Math.Round(r.LanguageEase.Value) <= 5
                    ? (LanguageDependence?)((int)Math.Round(r.LanguageEase.Value))
                    : null,
            r.BestPlayers,
            r.GoodPlayers,
            r.NumOwned,
            r.NumWant,
            r.NumWish,
            r.NumWeightVotes,
            r.MfgPlayTime,
            r.ComMinPlaytime,
            r.ComMaxPlaytime,
            r.MfgAgeRec,
            r.IsReimplementation,
            r.RankBoardGame,
            families.FirstOrDefault(f => f.Name == r.Family)?.Name,
            r.ImagePath)).OrderBy(r => r.BggId).ToList();

        var boardGameCategories = records
            .SelectMany(r =>
            {
                return categoriesProperties
                .Where(p =>
                {
                    var gameInCategory = (bool)p.GetValue(r)!;
                    return gameInCategory;
                })
                .Select(p => new BoardGameClassifierRelationCsvReturnDto(
                    r.BggId,
                    (categories.FirstOrDefault(
                        c => $"Cat:{c.Name}" == (
                            p.GetCustomAttribute<NameAttribute>()?
                            .Names
                            .FirstOrDefault(n => n.StartsWith("Cat:", StringComparison.OrdinalIgnoreCase))))?.Name) ?? ""));
            })
            .ToList();

        return new BoardGamesCsvResultDto(boardGames, families, categories, boardGameCategories);
    }

    private static List<ClassifierCsvReturnDto> GetCategoriesFromImportedData(string[] headerRecords)
    {
        var categories = headerRecords.Where(headerRecords => headerRecords.StartsWith("Cat:")).ToList();
        return categories.Select(c => new ClassifierCsvReturnDto(c.Split(":")[1])).ToList();
    }
}
