using TabletopConnect.API.Controllers.Dtos.Classifiers;
using TabletopConnect.Application.Services.Dtos.Classifiers;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.API.Controllers.Dtos.BoardGames;

public record BoardGameDetailsResponse(
    BoardGameResponse BoardGame,
    List<CategoryWithPositionResponse> Categories,
    List<ClassifierItemResponse> Designers,
    List<ClassifierItemResponse> Mechanics,
    List<ClassifierItemResponse> Publishers,
    List<ClassifierItemResponse> Subcategories,
    List<ClassifierItemResponse> Themes,
    ClassifierItemResponse? Family);

public record BoardGameResponse(
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

public record CategoryWithPositionResponse(
    int? Position,
    ClassifierItemResponse Category);