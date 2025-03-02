using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TabletopConnect.Application.Services.Interfaces;

namespace TabletopConnect.API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class PlayerProfilesController : ControllerBase
{
    private readonly IPlayerProfilesService _playerProfilesService;

    public PlayerProfilesController(IPlayerProfilesService playerProfilesService)
    {
        _playerProfilesService = playerProfilesService;
    }

    [HttpPost("{profileId}/favourite-games/{boardGameId}")]
    public async Task<IActionResult> AddPlayerFavouriteGame(int profileId, int boardGameId, CancellationToken cancellation)
    {
        var result = await _playerProfilesService.AddFavouriteGameAsync(profileId, boardGameId, cancellation);
        return result ? Ok() : BadRequest();
    }

    [HttpDelete("{profileId}/favourite-games/{boardGameId}")]
    public async Task<IActionResult> RemovePlayerFavouriteGame(int profileId, int boardGameId, CancellationToken cancellation)
    {
        var result = await _playerProfilesService.RemoveFavouriteGameAsync(profileId, boardGameId, cancellation);
        return result ? Ok() : BadRequest();
    }
}
