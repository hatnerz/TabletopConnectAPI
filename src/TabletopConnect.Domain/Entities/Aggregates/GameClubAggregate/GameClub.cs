using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Domain.Entities.Common.ValueObjects;
using TabletopConnect.Domain.Validators;

namespace TabletopConnect.Domain.Entities.Aggregates.GameClubAggregate;
public class GameClub : SoftEntity<int>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string PhoneNumber { get; private set; }
    public Location Location { get; private set; }

    public int OwnerId { get; set; }

    public GameClub(string name, string description, string phoneNumber, Location location, int ownerId)
    {
        CredentialsValidators.ValidatePhoneNumber(phoneNumber, nameof(PhoneNumber));

        Name = name;
        Description = description;
        PhoneNumber = phoneNumber;
        Location = location;
        OwnerId = ownerId;
    }
}
