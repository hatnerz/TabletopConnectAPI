using TabletopConnect.API.Controllers.Dtos.Classifiers;
using TabletopConnect.Application.Services.Dtos.BoardGames;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.API.Controllers.Dtos.BoardGames;

public record BoardGamesPaginationResponse(
    int TotalCount,
    List<BoardGameSummaryResponse> BoardGames);

public record BoardGameSummaryResponse(
    int Id,
    string Name,
    string? Description,
    int YearPublished,
    int? BggRank,
    double? BggScore,
    string? ImageUrl,
    int MinPlayers,
    int MaxPlayers,
    int? FamilyId,
    string? FamilyName,
    LanguageDependence LanguageDependence,
    string LanguageDependenceName,
    List<ClassifierItemResponse> Categories);