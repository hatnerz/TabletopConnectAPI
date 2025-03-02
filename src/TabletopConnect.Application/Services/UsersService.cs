using TabletopConnect.Application.Infrastucture.Interfaces;
using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Application.Services.Dtos.Users;
using TabletopConnect.Application.Services.Interfaces;
using TabletopConnect.Application.Services.Validation;
using TabletopConnect.Common.Constants;
using TabletopConnect.Domain.Entities.Aggregates.PlayerProfile;
using TabletopConnect.Domain.Entities.IAM;

namespace TabletopConnect.Application.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _userRepository;
    private readonly IPlayerProfilesRepository _playerProfilesRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IGoogleAuthService _googleAuthService;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IUnitOfWork _unitOfWork;

    public UsersService(
        IUsersRepository userRepository,
        IPlayerProfilesRepository playerProfilesRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenService jwtTokenService,
        IGoogleAuthService googleAuthService,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _playerProfilesRepository = playerProfilesRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
        _googleAuthService = googleAuthService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ValidationResultDto> RegisterAsync(AuthDto dto, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(dto.Email, cancellationToken);
        if (existingUser != null)
        {
            var error = new ValidationErrorDto(
                ValidationMessages.Common.EntityAlreadyExists(nameof(User), nameof(User.Email)),
                nameof(User.Email));

            return ValidationResultDto.CreateFailure([error]);
        }

        var hashedPassword = _passwordHasher.HashPassword(dto.Password);
        var user = User.RegisterRegular(dto.Email, hashedPassword);

        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var playerProfile = new PlayerProfile(user.Id);
        _playerProfilesRepository.Add(playerProfile);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ValidationResultDto.CreateSuccess();
    }

    public async Task<AuthResultDto> AuthenticateAsync(AuthDto dto, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email, cancellationToken);
        if (user == null || string.IsNullOrEmpty(user.PasswordHash))
            return new AuthResultDto(null);

        var playerProfile = await _userRepository.GetLinkedPlayerProfile(user.Id, cancellationToken);
        if (playerProfile == null)
            return new AuthResultDto(null);

        var result = _passwordHasher.VerifyPassword(user.PasswordHash, dto.Password);

        if (!result)
            return new AuthResultDto(null);

        var token = _jwtTokenService.GenerateToken(user, playerProfile.Id);

        return new AuthResultDto(token);
    }

    public async Task<AuthResultDto> AuthenticateWithGoogleAsync(string token, CancellationToken cancellationToken)
    {
        var googleUser = await _googleAuthService.ValidateGoogleTokenAsync(token);

        if (googleUser == null)
            return new AuthResultDto(null);

        var emailUser = await _userRepository.GetByEmailAsync(googleUser.Email, cancellationToken);
        var user = await _userRepository.GetByGoogleIdAsync(googleUser.GoogleId, cancellationToken);

        if (emailUser != null && user == null)
            return new AuthResultDto(null);

        if (emailUser != null && user != null && emailUser.Id != user.Id)
            return new AuthResultDto(null);

        if (user == null)
        {
            user = User.RegisterGoogle(googleUser.Email, googleUser.EmailVerified, googleUser.GoogleId);
            _userRepository.Add(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var nickname = GenerateNicknameFromEmail(googleUser.Email);
            var playerProfile = new PlayerProfile(
                user.Id, googleUser.FirstName, googleUser.LastName, nickname, null, googleUser.ProfilePictureUrl);
            _playerProfilesRepository.Add(playerProfile);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        var linkedPlayerProfile = await _userRepository.GetLinkedPlayerProfile(user.Id, cancellationToken);
        var jwtToken = _jwtTokenService.GenerateToken(user, linkedPlayerProfile!.Id);

        return new AuthResultDto(jwtToken);
    }

    public async Task<ValidationResultDto> LinkGoogleAccountAsync(LinkGoogleDto dto, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(dto.UserId, cancellationToken);
        var playerProfile = await _userRepository.GetLinkedPlayerProfile(dto.UserId, cancellationToken);
        var googleUser = await _googleAuthService.ValidateGoogleTokenAsync(dto.GoogleToken);
        if (user == null || playerProfile == null || googleUser == null)
            return ValidationResultDto.CreateFailure();

        var existingUserWithLinkedGoogle = await _userRepository.GetByGoogleIdAsync(googleUser.GoogleId, cancellationToken);
        if (existingUserWithLinkedGoogle != null)
        {
            var error = new ValidationErrorDto(ValidationMessages.Common.EntityAlreadyExists(nameof(User), nameof(User.GoogleId)));
            return ValidationResultDto.CreateFailure([error]);
        }

        user.LinkGoogle(googleUser.GoogleId);
        playerProfile.UpdateIfNotNull(
            googleUser.FirstName,
            googleUser.LastName,
            GenerateNicknameFromEmail(googleUser.Email),
            null,
            googleUser.ProfilePictureUrl);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ValidationResultDto.CreateSuccess();
    }

    private static string GenerateNicknameFromEmail(string email)
    {
        return email[0..6];
    }
}