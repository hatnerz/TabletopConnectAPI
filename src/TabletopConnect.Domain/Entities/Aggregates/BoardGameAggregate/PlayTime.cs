using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Domain.Validators;

namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public class PlayTime
{
    public int ManufacturerStatedPlayTime { get; set; }
    public int? CommunityMinPlayTime { get; set; }
    public int? CommunityMaxPlayTime { get; set; }

    public PlayTime(int manufacturerStatedPlayTime, int? communityMinPlayTime, int? communityMaxPlayTime)
    {
        NumberValidators.ValidateRangeInclusive<int>(manufacturerStatedPlayTime, 0, null, nameof(ManufacturerStatedPlayTime));
        NumberValidators.ValidateRangeInclusive(communityMinPlayTime, 0, null, nameof(CommunityMinPlayTime));
        NumberValidators.ValidateRangeInclusive(communityMaxPlayTime, 0, null, nameof(CommunityMaxPlayTime));

        ManufacturerStatedPlayTime = manufacturerStatedPlayTime;
        CommunityMinPlayTime = communityMinPlayTime;
        CommunityMaxPlayTime = communityMaxPlayTime;
    }
}
