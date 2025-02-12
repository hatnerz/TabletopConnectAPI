using TabletopConnect.Domain.Validators;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class RecommendedPlayers
{
    private readonly List<int>? _goodPlayers;

    public int BestPlayers { get; private set; }
    public IReadOnlyCollection<int>? GoodPlayers => _goodPlayers?.AsReadOnly();

    public RecommendedPlayers(int bestPlayers, List<int>? goodPlayers)
    {
        NumberValidators.ValidateRangeInclusive<int>(bestPlayers, 0, null, nameof(BestPlayers));

        BestPlayers = bestPlayers;
        _goodPlayers = goodPlayers;
    }
}
