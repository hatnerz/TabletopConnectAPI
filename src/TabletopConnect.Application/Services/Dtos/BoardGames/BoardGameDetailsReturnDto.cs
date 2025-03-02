using TabletopConnect.Application.Services.Dtos.Classifiers;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Application.Services.Dtos.BoardGames;

public record BoardGameDetailsReturnDto(
    BoardGameReturnDto BoardGame,
    List<CategoryWithPositionReturnDto> Categories,
    List<ClassifierReturnDto> Designers,
    List<ClassifierReturnDto> Mechanics,
    List<ClassifierReturnDto> Publishers,
    List<ClassifierReturnDto> Subcategories,
    List<ClassifierReturnDto> Themes,
    ClassifierReturnDto? Family);

public record BoardGameReturnDto(
    int Id,
    string Name,
    string? Description,
    int YearPublished,
    double GameComplexity,
    bool IsReimplementation,
    string ImagePath,
    int ManufacturerStatedPlayTime,
    int? CommunityMinPlayTime,
    int? CommunityMaxPlayTime,
    int ManufacturerRecommendedAge,
    int? CommunityRecommendedAge,
    int MinPlayers,
    int MaxPlayers,
    int? BestPlayers,
    IReadOnlyCollection<int>? GoodPlayers,
    int? BggId,
    double? BggScore,
    double? AverageRating,
    int? RankOverall,
    LanguageDependence LanguageDependence,
    string LanguageDependenceName);

public record CategoryWithPositionReturnDto(
    int? Position,
    ClassifierReturnDto Category);