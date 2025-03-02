using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Application.Persistence.Interfaces.Dtos.BoardGames;

public record BoardGamesFilterDto(
    List<int>? CategoryIds,
    List<int>? FamiliesIds,
    List<int>? MechanicsIds,
    List<int>? ThemeIds,
    int? MinPlayTime,
    int? MaxPlayTime,
    int? Players,
    LanguageDependence? LanguageDependence);