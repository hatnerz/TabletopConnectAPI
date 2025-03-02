using TabletopConnect.API.Mapping;
using TabletopConnect.Common.Enums;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.API.Controllers.Dtos.BoardGames;

public record BoardGamesPaginationRequest(
    BoardGamesFilterRequest? Filter,
    BoardGamesSortingRequest? Sorting,
    string? Search,
    int? PageNumber,
    int? PageSize);

public record BoardGamesFilterRequest(
    List<int>? CategoryIds,
    List<int>? FamiliesIds,
    List<int>? MechanicsIds,
    List<int>? ThemeIds,
    int? MinPlayTime,
    int? MaxPlayTime,
    int? Players,
    LanguageDependence? LanguageDependence);

public record BoardGamesSortingRequest(
    SortingDirection? Name,
    SortingDirection? YearPublished,
    SortingDirection? GameComplexity,
    SortingDirection? LanguageDependence,
    SortingDirection? BggRank,
    SortingDirection? BggScore) : ISortingRequest;