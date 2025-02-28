using TabletopConnect.API.Mapping;
using TabletopConnect.Application.Persistence.Interfaces.Dtos.BoardGames;
using TabletopConnect.Application.Services.Dtos.Common;
using TabletopConnect.Common.Constants;
using TabletopConnect.Common.Enums;

namespace TabletopConnect.API.Controllers.Dtos.BoardGames;

public record BoardGamesPaginationRequest(
    BoardGamesFilterRequest? Filter,
    BoardGamesSortingRequest? Sorting,
    string? Search,
    int? PageNumber,
    int? PageSize);

public record BoardGamesFilterRequest(
    List<int>? CategoryIds);

public record BoardGamesSortingRequest(
    SortingDirection? Name,
    SortingDirection? YearPublished) : ISortingRequest;