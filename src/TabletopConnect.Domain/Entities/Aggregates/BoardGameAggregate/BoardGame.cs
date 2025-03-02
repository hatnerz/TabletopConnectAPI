using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Domain.Validators;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BoardGame : SoftEntity<int>
{
    private readonly List<BoardGameCategory> _boardGameCategories = new();
    private readonly List<BoardGameSubcategory> _boardGameSubcategories = new();
    private readonly List<BoardGameDesigner> _boardGameDesigners = new();
    private readonly List<BoardGameMechanics> _boardGameMechanics = new();
    private readonly List<BoardGamePublisher> _boardGamePublishers = new();
    private readonly List<BoardGameTheme> _boardGameThemes = new();

    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public int YearPublished { get; private set; }
    public double GameComplexity { get; private set; }
    public bool IsReimplementation { get; private set; }
    public string ImagePath { get; private set; } = null!;
    public PlayTime PlayTime { get; private set; } = null!;
    public RecommendedAge RecommendedAge { get; private set; } = null!;
    public Players Players { get; private set; } = null!;
    public BggData? BggData { get; private set; }
    public LanguageDependence LanguageDependence { get; private set; }
    public int? ExpansionForId { get; set; }
    public int? FamilyId { get; set; }

    public IReadOnlyCollection<BoardGameCategory> BoardGameCategories => _boardGameCategories.AsReadOnly();
    public IReadOnlyCollection<BoardGameSubcategory> BoardGameSubcategories => _boardGameSubcategories.AsReadOnly();
    public IReadOnlyCollection<BoardGameDesigner> BoardGameDesigners => _boardGameDesigners.AsReadOnly();
    public IReadOnlyCollection<BoardGameMechanics> BoardGameMechanics => _boardGameMechanics.AsReadOnly();
    public IReadOnlyCollection<BoardGamePublisher> BoardGamePublishers => _boardGamePublishers.AsReadOnly();
    public IReadOnlyCollection<BoardGameTheme> BoardGameThemes => _boardGameThemes.AsReadOnly();

    private BoardGame()
    {
    }

    public BoardGame(
        string name,
        string? description,
        int yearPublished,
        double gameComplexity,
        bool isReimplementation,
        string imagePath,
        PlayTime playTime,
        RecommendedAge recommendedAge,
        Players recommendedPlayers,
        BggData? bggData,
        LanguageDependence languageDependence,
        int? expansionForId,
        int? familyId)
    {
        TextValidators.ValidateRequiredTextProperty(name, 200, nameof(Name));
        TextValidators.ValidateTextProperty(description, 9000, nameof(Description));
        NumberValidators.ValidateRangeInclusive<double>(gameComplexity, 1, 5, nameof(GameComplexity));

        Name = name;
        Description = description;
        YearPublished = yearPublished;
        GameComplexity = gameComplexity;
        IsReimplementation = isReimplementation;
        ImagePath = imagePath;
        PlayTime = playTime;
        RecommendedAge = recommendedAge;
        Players = recommendedPlayers;
        BggData = bggData;
        LanguageDependence = languageDependence;
        ExpansionForId = expansionForId;
        FamilyId = familyId;
    }
}
