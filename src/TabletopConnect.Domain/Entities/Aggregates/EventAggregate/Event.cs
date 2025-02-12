using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Domain.Entities.Common.ValueObjects;
using TabletopConnect.Domain.Validators;

namespace TabletopConnect.Domain.Entities.Aggregates.EventAggregate;

public class Event : SoftEntity<int>
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public int? MaxPlayers { get; private set; }
    public int? MinPlayers { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsOnline { get; private set; }
    public Location? Location { get; private set; }
    public EventType EventType { get; private set; }
    public decimal? Price { get; private set; }
    public int? BoardGameId { get; private set; }

    public Event(
        string name,
        string? description,
        int? maxPlayers,
        int? minPlayers,
        DateTime startDate,
        DateTime endDate,
        bool isOnline,
        Location? location,
        EventType eventType,
        decimal? price,
        int? boardGameId)
    {
        TextValidators.ValidateRequiredTextProperty(name, 150, nameof(Name));
        TextValidators.ValidateTextProperty(description, 2000, nameof(Description));
        DateValidators.ValidateDates(startDate, endDate, nameof(StartDate));

        int? maxPlayerValidationMinimum = null;
        
        if (minPlayers != null)
        {
            NumberValidators.ValidateRangeInclusive<int>(minPlayers.Value, 0, maxPlayers, nameof(MinPlayers));
            maxPlayerValidationMinimum = minPlayers.Value;
        }

        NumberValidators.ValidateRangeInclusive(maxPlayers, maxPlayerValidationMinimum, null, nameof(MaxPlayers));

        Name = name;
        Description = description;
        MaxPlayers = maxPlayers;
        MinPlayers = minPlayers;
        StartDate = startDate;
        EndDate = endDate;
        IsOnline = isOnline;
        Location = location;
        EventType = eventType;
        Price = price;
        BoardGameId = boardGameId;

    }
}
