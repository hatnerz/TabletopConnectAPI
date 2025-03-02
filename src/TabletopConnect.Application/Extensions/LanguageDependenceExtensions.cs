using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Application.Extensions;
public static class LanguageDependenceExtensions
{
    private static readonly Dictionary<LanguageDependence, string> _values = new()
    {
        { LanguageDependence.Unplayable, "Unplayable in another language" },
        { LanguageDependence.NoInGameText, "No necessary in-game text" },
        { LanguageDependence.SomeInGameText, "Some necessary in-game text" },
        { LanguageDependence.ModerateInGameText, "Moderate in-game text" },
        { LanguageDependence.ExtensiveInGameText, "Extensive use of text" },
        { LanguageDependence.Unknown, "Unknown" }
    };

    public static string GetDisplayName(this LanguageDependence dependence) =>
        _values.TryGetValue(dependence, out var value) ? value : "Unknown";
}