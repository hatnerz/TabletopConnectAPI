using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
using System.Reflection;
using System.Reflection.PortableExecutable;
using TabletopConnect.Application.Infrastucture.Interfaces;
using TabletopConnect.Application.Infrastucture.Interfaces.Dtos;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;
using TabletopConnect.Infrastructure.DataImporters.Dtos;

namespace TabletopConnect.Infrastructure.DataImporters;

internal class BoardGamesCsvImportService : IBoardGamesCsvImportService
{
    private readonly CsvConfiguration csvReaderConfig = new(CultureInfo.InvariantCulture)
    {
        Delimiter = ";",
        MissingFieldFound = null
    };
    private const string bggIdHeaderColumnName = "BGGId";
    private const string categoryHeaderColumnPrefix = "Cat:";
    private const string rankHeaderColumnName = "Rank:";
    private const string themeHeaderColumnPrefix = "Theme_";

    public BoardGamesCsvResultDto GetBoardGamesImportedData(Stream csvStream)
    {
        csvStream.Position = 0;
        if (csvStream == null || csvStream.Length == 0)
            throw new ArgumentException("CSV stream is empty.", nameof(csvStream));


        using var reader = new StreamReader(csvStream);
        using var csv = new CsvReader(reader, csvReaderConfig);
        var records = new List<BoardGameCsvInputDto>();

        var categoriesProperties = typeof(BoardGameCsvInputDto)
            .GetProperties()
            .Where(prop => {
                var attribute = prop.GetCustomAttribute<NameAttribute>();
                return attribute != null && attribute.Names.Any(n => n.StartsWith(categoryHeaderColumnPrefix, StringComparison.OrdinalIgnoreCase));
            })
            .ToList();

        var rankProperties = typeof(BoardGameCsvInputDto)
            .GetProperties()
            .Where(prop => {
                var attribute = prop.GetCustomAttribute<NameAttribute>();
                return attribute != null && attribute.Names.Any(n => n.StartsWith(rankHeaderColumnName, StringComparison.OrdinalIgnoreCase));
            });

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
                .Select(p => new BoardGameCategoryRelationCsvReturnDto(
                    r.BggId,
                    (categories.FirstOrDefault(
                        c => $"{categoryHeaderColumnPrefix}{c.Name}" == (
                            p.GetCustomAttribute<NameAttribute>()?
                            .Names
                            .FirstOrDefault(n => n.StartsWith(categoryHeaderColumnPrefix, StringComparison.OrdinalIgnoreCase))))?.Name) ?? "",
                    rankProperties.FirstOrDefault(
                        rankProp => rankProp.GetCustomAttribute<NameAttribute>()?
                            .Names.FirstOrDefault(n => n.StartsWith(rankHeaderColumnName, StringComparison.OrdinalIgnoreCase))?.Replace(rankHeaderColumnName, "") 
                                == p.GetCustomAttribute<NameAttribute>()?.Names.FirstOrDefault(n => n.StartsWith(categoryHeaderColumnPrefix, StringComparison.OrdinalIgnoreCase))?.Replace(categoryHeaderColumnPrefix, ""))
                        ?.GetValue(r) as int? ?? 0));
            })
            .ToList();

        return new BoardGamesCsvResultDto(boardGames, families, categories, boardGameCategories);
    }

    public ClassifiersWithRelationsCsvResultDto GetClassifiersWithRelationsImportedDataDefault(Stream csvStream)
    {
        return GetClassifiersWithRelationsImportedData(csvStream, null);
    }

    public ClassifiersWithRelationsCsvResultDto GetThemesImportedData(Stream csvStream)
    {
        return GetClassifiersWithRelationsImportedData(csvStream, GetThemeNameFromHeader);
    }

    private ClassifiersWithRelationsCsvResultDto GetClassifiersWithRelationsImportedData(
        Stream csvStream,
        Func<string, string>? classifierNameTransformSelector)
    {
        using var reader = new StreamReader(csvStream);
        using var csv = new CsvReader(reader, csvReaderConfig);

        csv.Read();
        csv.ReadHeader();

        if (csv.HeaderRecord == null)
            throw new InvalidOperationException("CSV header is null.");

        var classifierRecords = csv.HeaderRecord.Where(r => r != bggIdHeaderColumnName).ToList();
        var classifiersDictionary = csv.HeaderRecord
            .Select((name, index) => new { name, index })
            .Where(r => r.name != bggIdHeaderColumnName)
            .ToDictionary(x => x.index, x => x.name);

        var classifierNames = classifierRecords;
        if (classifierNameTransformSelector != null)
        {
            classifierNames = classifierNames.Select(classifierName => classifierNameTransformSelector(classifierName)).ToList();
        }

        var classifiers = classifierNames.Select(p => new ClassifierCsvReturnDto(p)).ToList();


        var boardGameWithClassifiersRelations = new List<BoardGameClassifierRelationCsvReturnDto>();


        while (csv.Read())
        {
            int gameIdFieldIndex = csv.GetFieldIndex("BGGId");
            int gameId = csv.GetField<int>(gameIdFieldIndex);

            for (int i = 0; i < csv.HeaderRecord.Length; i++)
            {
                if (i != gameIdFieldIndex && csv.GetField<int>(i) == 1)
                {
                    boardGameWithClassifiersRelations.Add(new(gameId, classifiersDictionary[i]));
                }
            }
        }

        return new(classifiers, boardGameWithClassifiersRelations);
    }

    private static List<ClassifierCsvReturnDto> GetCategoriesFromImportedData(string[] headerRecords)
    {
        var categories = headerRecords.Where(headerRecords => headerRecords.StartsWith(categoryHeaderColumnPrefix)).ToList();
        return categories.Select(c => new ClassifierCsvReturnDto(c.Split(":")[1])).ToList();
    }

    private static string GetThemeNameFromHeader(string header)
    {
        if (header.StartsWith(themeHeaderColumnPrefix))
            return header.Replace(themeHeaderColumnPrefix, "");

        return header;
    }
}
