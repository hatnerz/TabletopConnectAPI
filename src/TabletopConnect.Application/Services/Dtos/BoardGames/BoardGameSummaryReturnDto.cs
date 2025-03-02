using TabletopConnect.Application.Services.Dtos.Classifiers;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Application.Services.Dtos.BoardGames;

public record BoardGameSummaryReturnDto(
    int Id,
    string Name,
    string? Description,
    int YearPublished,
    int? BggRank,
    double? BggScore,
    string? ImageUrl,
    int MinPlayers,
    int MaxPlayers,
    int MinPlayTime,
    int MaxPlayTime,
    int? FamilyId,
    string? FamilyName,
    LanguageDependence LanguageDependence,
    string LanguageDependenceName,
    List<ClassifierReturnDto> Categories);