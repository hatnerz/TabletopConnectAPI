using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.Application.Persistence.Interfaces.Dtos.BoardGames;

public record BoardGameDetails(
    BoardGame BoardGame,
    List<CategoryWithPosition> Categories,
    List<Designer> Designers,
    List<Mechanics> Mechanics,
    List<Publisher> Publishers,
    List<Subcategory> Subcategories,
    List<Theme> Themes,
    Family? Family);

public record CategoryWithPosition(
    int? Position,
    Category Category);