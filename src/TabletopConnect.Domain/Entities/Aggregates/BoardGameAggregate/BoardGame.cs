using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Domain.Validators;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGame : SoftEntity<int>
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public int YearPublished { get; private set; }
    public double GameComplexity { get; private set; }
    public bool IsReimplementation { get; private set; }
    public string ImagePath { get; private set; }
    public PlayTime PlayTime { get; private set; }
    public RecommendedAge RecommendedAge { get; private set; }
    public RecommendedPlayers RecommendedPlayers { get; private set; }
    public BggData? BggData { get; private set; }
    public LanguageDependence LanguageDependence { get; private set; }
    public int? ExpansionForId { get; set; }
    public int? FamilyId { get; set; }

    public BoardGame(
        string name,
        string? description,
        int yearPublished,
        double gameComplexity,
        bool isReimplementation,
        string imagePath,
        PlayTime playTime,
        RecommendedAge recommendedAge,
        RecommendedPlayers recommendedPlayers,
        BggData? bggData,
        LanguageDependence languageDependence,
        int? expansionForId,
        int? familyId)
    {
        TextValidators.ValidateRequiredTextProperty(name, 100, nameof(Name));
        TextValidators.ValidateTextProperty(description, 200, nameof(Name));
        NumberValidators.ValidateRangeInclusive<double>(gameComplexity, 1, 5, nameof(GameComplexity));

        Name = name;
        Description = description;
        YearPublished = yearPublished;
        GameComplexity = gameComplexity;
        IsReimplementation = isReimplementation;
        ImagePath = imagePath;
        PlayTime = playTime;
        RecommendedAge = recommendedAge;
        RecommendedPlayers = recommendedPlayers;
        BggData = bggData;
        LanguageDependence = languageDependence;
        ExpansionForId = expansionForId;
        FamilyId = familyId;
    }
}
