using TabletopConnect.API.Controllers.Dtos.Classifiers;
using TabletopConnect.Application.Services.Dtos.BoardGames;

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
    List<ClassifierItemResponse> Categories);