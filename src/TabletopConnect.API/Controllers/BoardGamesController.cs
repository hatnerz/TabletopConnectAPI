using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TabletopConnect.API.Controllers.Dtos.BoardGames;
using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Application.Persistence.Interfaces.Dtos.BoardGames;
using TabletopConnect.Application.Services.Dtos.BoardGames;
using TabletopConnect.Application.Services.Interfaces;
using TabletopConnect.Application.Services.Recommendations;
using TabletopConnect.Common.Enums;

namespace TabletopConnect.API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class BoardGamesController : ControllerBase
{
    private readonly IBoardGamesRepository _boardGamesRepository;
    private readonly IBoardGamesService _boardGamesService;
    private readonly IMapper _mapper;

    public BoardGamesController(
        IBoardGamesRepository boardGamesRepository,
        IBoardGamesService boardGamesService,
        IMapper mapper)
    {
        _boardGamesRepository = boardGamesRepository;
        _boardGamesService = boardGamesService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> GetBoardGames(
        [FromBody]BoardGamesPaginationRequest request, CancellationToken cancellation)
    {
        var dto = _mapper.Map<BoardGamesPaginationDto>(request);
        var result = await _boardGamesService.GetBoardGamesSummaryAsync(dto, cancellation);
        return Ok(_mapper.Map<BoardGamesPaginationResponse>(result));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBoardGame(
        int id, CancellationToken cancellation)
    {
        var result = await _boardGamesService.GetBoardGameDetails(id, cancellation);
        return Ok(_mapper.Map<BoardGameDetailsResponse>(result));
    }

    [HttpGet("recommendations")]
    public async Task<IActionResult> GetRecommendedBoardGames()
    {
        var games = await _boardGamesRepository.GetAllReadonlyAsync();
        var service = new BoardGamesRecommendationsService(games);
        var result = service.RecommendGames([15361], 100);
        return Ok(result);
    }
}
