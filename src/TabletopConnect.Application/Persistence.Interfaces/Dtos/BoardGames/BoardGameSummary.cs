using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Application.Persistence.Interfaces.Dtos.BoardGames;

public record BoardGameSummary(
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
    List<Category> Categories);