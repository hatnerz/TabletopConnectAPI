using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Infrastructure.DataImporters.Dtos;

public record BoardGameCsvReturnDto(
    int BggId,
    string Name,
    string Description,
    int YearPublished,
    double GameWeight,
    double BayesAvgRating,
    double AvgRating,
    int MinPlayers,
    int MaxPlayers,
    int? ComAgeRec,
    LanguageDependence? LanguageEase,
    int BestPlayers,
    string GoodPlayers,
    int NumOwned,
    int NumWant,
    int NumWish,
    int NumWeightVotes,
    int MfgPlayTime,
    int ComMinPlaytime,
    int ComMaxPlaytime,
    int MfgAgeRec,
    bool IsReimplementation,
    int OverallRank,
    string? FamilyName,
    string ImagePath);
