namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class BggData
{
    public int BggId { get; private set; }
    public double BggScore { get; private set; }
    public int NumberOwned { get; private set; }
    public int NumberWanted { get; private set; }
    public int NumberWished { get; private set; }
    public int NumberWeightVotes { get; private set; }
    public int AverageRating { get; private set; }
    public int RankOverall { get; private set; }

    public BggData(
        int bggId,
        double bggScore,
        int numberOwned,
        int numberWanted,
        int numberWished,
        int numberWeightVotes,
        int averageRating,
        int rankOverall)
    {
        BggId = bggId;
        BggScore = bggScore;
        NumberOwned = numberOwned;
        NumberWanted = numberWanted;
        NumberWished = numberWished;
        NumberWeightVotes = numberWeightVotes;
        AverageRating = averageRating;
        RankOverall = rankOverall;
    }
}
