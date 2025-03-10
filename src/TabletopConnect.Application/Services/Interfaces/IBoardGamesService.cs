﻿using TabletopConnect.Application.Services.Dtos.BoardGames;

namespace TabletopConnect.Application.Services.Interfaces;

public interface IBoardGamesService
{
    Task<BoardGamesPaginationReturnDto> GetBoardGamesSummaryAsync(BoardGamesPaginationDto pagination, CancellationToken cancellationToken = default);

    Task<BoardGameDetailsReturnDto?> GetBoardGameDetails(int id, CancellationToken cancellationToken = default);
}
