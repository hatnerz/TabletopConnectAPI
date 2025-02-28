using TabletopConnect.Application.Persistence.Interfaces.Dtos.BoardGames;
using TabletopConnect.Application.Services.Dtos.Common;

namespace TabletopConnect.Application.Services.Dtos.BoardGames;

public class BoardGamesPaginationDto : PaginationDto
{
    public BoardGamesFilterDto? Filter { get; set; }
}
