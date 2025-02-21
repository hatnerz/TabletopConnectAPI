namespace TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

public enum LanguageDependence
{
    Unknown = 0,
    NoInGameText = 1, // No necessary in-game text
    SomeInGameText = 2, // Some necessary text - easily memorized or small crib sheet
    ModerateInGameText = 3, // Moderate in-game text - needs crib sheet or paste ups
    ExtensiveInGameText = 4, // Extensive use of text - massive conversion needed to be playable
    Unplayable = 5 // Unplayable in another language
}
