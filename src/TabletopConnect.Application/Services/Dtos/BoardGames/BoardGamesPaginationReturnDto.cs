namespace TabletopConnect.Application.Services.Dtos.BoardGames;

public record BoardGamesPaginationReturnDto(
    int TotalCount,
    List<BoardGameSummaryReturnDto> BoardGames);
