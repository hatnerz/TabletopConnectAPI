using CsvHelper.Configuration.Attributes;

namespace TabletopConnect.Infrastructure.DataImporters.Dtos;

public class BoardGameCsvInputDto
{
    [Name("BGGId")]
    public int BggId { get; set; }

    [Name("Name")]
    public string Name { get; set; } = null!;

    [Name("Description")]
    public string Description { get; set; } = null!;

    [Name("YearPublished")]
    public int YearPublished { get; set; }

    [Name("GameWeight")]
    public double GameWeight { get; set; }

    [Name("AvgRating")]
    public double AvgRating { get; set; }

    [Name("BayesAvgRating")]
    public double BayesAvgRating { get; set; }

    [Name("StdDev")]
    public double StdDev { get; set; }

    [Name("MinPlayers")]
    public int MinPlayers { get; set; }

    [Name("MaxPlayers")]
    public int MaxPlayers { get; set; }

    [Name("ComAgeRec")]
    public decimal? ComAgeRec { get; set; }

    [Name("LanguageEase")]
    public double? LanguageEase { get; set; }

    [Name("BestPlayers")]
    public int BestPlayers { get; set; }

    [Name("GoodPlayers")]
    public string GoodPlayers { get; set; } = null!;

    [Name("NumOwned")]
    public int NumOwned { get; set; }

    [Name("NumWant")]
    public int NumWant { get; set; }

    [Name("NumWish")]
    public int NumWish { get; set; }

    [Name("NumWeightVotes")]
    public int NumWeightVotes { get; set; }

    [Name("MfgPlaytime")]
    public int MfgPlayTime { get; set; }

    [Name("ComMinPlaytime")]
    public int ComMinPlaytime { get; set; }

    [Name("ComMaxPlaytime")]
    public int ComMaxPlaytime { get; set; }

    [Name("MfgAgeRec")]
    public int MfgAgeRec { get; set; }

    [Name("NumUserRatings")]
    public int NumUserRatings { get; set; }

    [Name("NumComments")]
    public int NumComments { get; set; }

    [Name("NumAlternates")]
    public int NumAlternates { get; set; }

    [Name("NumExpansions")]
    public int NumExpansions { get; set; }

    [Name("NumImplementations")]
    public int NumImplementations { get; set; }

    [Name("IsReimplementation")]
    public bool IsReimplementation { get; set; }

    [Name("Family")]
    public string? Family { get; set; }

    [Name("Kickstarted")]
    public bool Kickstarted { get; set; }

    [Name("ImagePath")]
    public string ImagePath { get; set; } = null!;

    [Name("Rank:boardgame")]
    public int RankBoardGame { get; set; }

    [Name("Rank:strategygames")]
    public int RankStrategyGames { get; set; }

    [Name("Rank:abstracts")]
    public int RankAbstracts { get; set; }

    [Name("Rank:familygames")]
    public int RankFamilyGames { get; set; }

    [Name("Rank:thematic")]
    public int RankThematic { get; set; }

    [Name("Rank:cgs")]
    public int RankCgs { get; set; }

    [Name("Rank:wargames")]
    public int RankWarGames { get; set; }

    [Name("Rank:partygames")]
    public int RankPartyGames { get; set; }

    [Name("Rank:childrensgames")]
    public int RankChildrensGames { get; set; }

    [Name("Cat:Thematic")]
    public bool CatThematic { get; set; }

    [Name("Cat:Strategy")]
    public bool CatStrategy { get; set; }

    [Name("Cat:WarGame")]
    public bool CatWarGame { get; set; }

    [Name("Cat:Family")]
    public bool CatFamily { get; set; }

    [Name("Cat:CardGame")]
    public bool CatCardGame { get; set; }

    [Name("Cat:Abstract")]
    public bool CatAbstract { get; set; }

    [Name("Cat:Party")]
    public bool CatParty { get; set; }

    [Name("Cat:Childrens")]
    public bool CatChildrens { get; set; }
}