using TabletopConnect.Domain.Validators;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class RecommendedAge
{
    public int ManufacturerRecomended { get; private set; }
    public int CommunityRecomended { get; private set; }

    public RecommendedAge(int manufacturerRecomended, int communityRecomended)
    {
        NumberValidators.ValidateRangeInclusive<int>(manufacturerRecomended, 0, null, nameof(ManufacturerRecomended));
        NumberValidators.ValidateRangeInclusive<int>(communityRecomended, 0, null, nameof(CommunityRecomended));

        ManufacturerRecomended = manufacturerRecomended;
        CommunityRecomended = communityRecomended;
    }
}
