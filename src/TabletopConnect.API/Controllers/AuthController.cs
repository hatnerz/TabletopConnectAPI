using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TabletopConnect.Application.Services.Interfaces;
using TabletopConnect.API.Controllers.Dtos.Auth;
using AutoMapper;
using TabletopConnect.Application.Services.Dtos.Users;
using TabletopConnect.API.Controllers.Dtos.Common;
using System.Security.Claims;
using TabletopConnect.Infrastructure.Authentication;
namespace TabletopConnect.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public AuthController(
        IUsersService usersService,
        ICurrentUserService currentUserService,
        IMapper mapper)
    {
        _usersService = usersService;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AuthRequest model, CancellationToken cancellation)
    {
        var authDto = _mapper.Map<AuthDto>(model);
        var registerResult = await _usersService.RegisterAsync(authDto, cancellation);

        if (!registerResult.Success)
            return BadRequest(new ValidationErrorResponse(registerResult.Errors));

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthRequest model, CancellationToken cancellation)
    {
        var authDto = _mapper.Map<AuthDto>(model);
        var authResult = await _usersService.AuthenticateAsync(authDto, cancellation);

        if (authResult.Token == null)
            return Unauthorized();

        return Ok(new AuthResponse(authResult.Token));
    }

    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin([FromBody] GoogleAuthRequest model, CancellationToken cancellation)
    {
        var authResult = await _usersService.AuthenticateWithGoogleAsync(model.Token, cancellation);

        if (authResult.Token == null)
            return Unauthorized();

        return Ok(new AuthResponse(authResult.Token));
    }

    [Authorize]
    [HttpPost("link-google")]
    public async Task<IActionResult> LinkGoogle([FromBody] LinkGoogleRequest model, CancellationToken cancellation)
    {
        var currentUser = _currentUserService.GetCurrentUser();

        if (currentUser == null)
            return Unauthorized();

        var linkDto = new LinkGoogleDto(
            currentUser.UserId,
            model.GoogleToken);
        var linkResult = await _usersService.LinkGoogleAccountAsync(linkDto, cancellation);

        if (!linkResult.Success)
            return BadRequest(new ValidationErrorResponse(linkResult.Errors));

        return Ok();
    }
}
