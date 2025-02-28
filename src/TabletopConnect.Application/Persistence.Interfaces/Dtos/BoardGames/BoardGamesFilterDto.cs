namespace TabletopConnect.Application.Persistence.Interfaces.Dtos.BoardGames;

public record BoardGamesFilterDto(
    List<int>? CategoryIds);