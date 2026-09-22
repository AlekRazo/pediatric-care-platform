using Pediatria.Application.DTOs.Auth;
using Pediatria.Application.DTOs.Users;
using Pediatria.Application.Interfaces.Repositories;
using Pediatria.Application.Interfaces.Services;
using Pediatria.Domain.Entities.Users;
using Pediatria.Domain.Exceptions;

namespace Pediatria.Application.Services;

public class AuthService : IAuthService
{
    private readonly ITokenRepository _tokenRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IClientInfoService _clientInforRepository;
    private readonly IJwtTokenService _jwtService;
    private readonly IEmailService _emailService;

    public AuthService(ITokenRepository tokenRepository, IUsersRepository usersRepository, IClientInfoService clientInfoRepository, IJwtTokenService jwtService, IEmailService emailService)
    {
        _tokenRepository = tokenRepository;
        _usersRepository = usersRepository;
        _clientInforRepository = clientInfoRepository;
        _jwtService = jwtService;
        _emailService = emailService;
    }

    public async Task<AuthResponseDto> Login(AuthRequestDto request)
    {
        var user = await _usersRepository.GetByUsernameAsync(request.Username);

        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedException("El usuario o contraseña son incorrectos");

        var jwtToken = _jwtService.CreateJWTToken(user);
        var rawRefreshToken = _jwtService.CreateRefreshToken();
        var currentTime = DateTime.UtcNow;

        var refreshToken = new RefreshToken
        {
            Id = Guid.CreateVersion7(),
            UserId = user.Id,
            TokenHash = _jwtService.HashToken(rawRefreshToken),
            CreatedAt = currentTime,
            ExpiresAt = currentTime.AddDays(7),
            Revoked = false,
            CreatedByIp = _clientInforRepository.GetClientIpAddress()
        };

        //Guardar Refresh Token
        var result = await _tokenRepository.AddRefreshTokenAsync(refreshToken);

        return new AuthResponseDto
        {
            UserId = user.Id,
            Token = jwtToken,
            RefreshToken = rawRefreshToken,
            Email = user.Email,
            IsActive = user.Active,
            Roles = user.UserRoles.Select(x => x.Role.Name).ToList()
        };
    }

    public async Task<bool> Logout(Guid id)
    {
        var result = await _tokenRepository.RevokeRefreshTokenAsync(id);

        if (result <= 0)
            return false;
        
        return true;
    }

    public async Task<bool> RecoverPassword(PasswordRecoveryRequestDto request)
    {
        var user = await _usersRepository.GetByUsernameAsync(request.Username);

        if (user is null || request.Email != user.Email)
            throw new UnauthorizedException("El usuario o correo electrónico son incorrectos");

        //Generar nueva contraseña
        Random random = new Random();
        string temporaryPassword = user.Username + random.Next(1,1000) + "!";

        //Guardar contraseña
        
        var adminGuid = _clientInforRepository.GetUserId();
        var currentTime = DateTime.UtcNow;

        if(adminGuid is null)
            throw new UnauthorizedException("La petición no tiene un administrador.");

        var passwordReset = new PasswordReset
        {
            Id = Guid.CreateVersion7(),
            UserId = user.Id,
            AdminId = adminGuid.Value,
            TempPasswordHash = BCrypt.Net.BCrypt.HashPassword(temporaryPassword),
            CreatedAt = currentTime,
            ExpiresAt = currentTime.AddHours(24),
            Used = false
        }; 

        await _emailService.SendPassowrdRecoveryEmailAsync(user.Email, temporaryPassword);
        return true;
    }

    public async Task<AuthResponseDto> RefreshToken(RefreshTokenRequestDto request)
    {
        var token = await _tokenRepository.GetActiveRefreshTokenAsync(request.RefreshToken);

        if(token is null || token.Revoked || token.ExpiresAt < DateTime.UtcNow)
            throw new UnauthorizedException("Refresh token inválido.");
        
        token.Revoked = true;

        var newAccessToken = _jwtService.CreateJWTToken(token.User);
        var newRefreshToken = _jwtService.CreateRefreshToken();
        var currentTime = DateTime.UtcNow;

        var refreshToken = new RefreshToken
        {
            Id = Guid.CreateVersion7(),
            UserId = token.UserId,
            TokenHash = _jwtService.HashToken(newRefreshToken),
            CreatedAt = currentTime,
            ExpiresAt = currentTime.AddDays(7),
            Revoked = false,
            CreatedByIp = _clientInforRepository.GetClientIpAddress()
        };

        //Guardar Refresh Token
        var result = await _tokenRepository.AddRefreshTokenAsync(refreshToken);

        return new AuthResponseDto
        {
            //UserId = token.UserId,
            Token = newAccessToken,
            RefreshToken = newRefreshToken
            //Email = token.User.Email,
            //IsActive = token.User.Active,
            //Roles = token.User.UserRoles.Select(x => x.Role.Name).ToList()
        };
    }
}