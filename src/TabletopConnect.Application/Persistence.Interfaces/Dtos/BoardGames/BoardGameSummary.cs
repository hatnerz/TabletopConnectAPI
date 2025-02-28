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
    List<Category> Categories);
