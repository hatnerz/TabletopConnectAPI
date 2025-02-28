using TabletopConnect.Application.Services.Dtos.Classifiers;

namespace TabletopConnect.Application.Services.Dtos.BoardGames;

public record BoardGameSummaryReturnDto(
    int Id,
    string Name,
    string? Description,
    int YearPublished,
    int? BggRank,
    double? BggScore,
    string? ImageUrl,
    List<ClassifierReturnDto> Categories);