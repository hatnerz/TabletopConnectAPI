using TabletopConnect.Domain.Validators;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class Players
{
    private readonly List<int>? _goodPlayers;

    public int MinPlayers { get; private set; }
    public int MaxPlayers { get; private set; }
    public int? BestPlayers { get; private set; }
    public IReadOnlyCollection<int>? GoodPlayers => _goodPlayers?.AsReadOnly();

    private Players()
    {
    }

    public Players(int minPlayers, int maxPlayers, int bestPlayers, List<int>? goodPlayers)
    {
        NumberValidators.ValidateRangeInclusive<int>(minPlayers, 0, null, nameof(BestPlayers));
        NumberValidators.ValidateRangeInclusive<int>(maxPlayers, 0, null, nameof(BestPlayers));
        NumberValidators.ValidateRangeInclusive<int>(bestPlayers, 0, null, nameof(BestPlayers));

        MinPlayers = minPlayers;
        MaxPlayers = maxPlayers;
        BestPlayers = bestPlayers;
        _goodPlayers = goodPlayers;
    }
}
