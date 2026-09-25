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
    private readonly IPasswordResetRepository _passwordResetRepository;
    private readonly IClientInfoService _clientInfoRepository;
    private readonly IJwtTokenService _jwtService;
    private readonly IEmailService _emailService;

    public AuthService(ITokenRepository tokenRepository, IUsersRepository usersRepository, IPasswordResetRepository passwordResetRepository, IClientInfoService clientInfoRepository, IJwtTokenService jwtService, IEmailService emailService)
    {
        _tokenRepository = tokenRepository;
        _usersRepository = usersRepository;
        _passwordResetRepository = passwordResetRepository;
        _clientInfoRepository = clientInfoRepository;
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
            CreatedByIp = _clientInfoRepository.GetClientIpAddress()
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

    public async Task<bool> Logout()
    {
        var id = _clientInfoRepository.GetUserId();

        if (id is null)
            throw new UnauthorizedException("No hay un usuario para cerrar sesión");

        var result = await _tokenRepository.RevokeAllRefreshTokensAsync(id.Value);

        if (result <= 0)
            return false;
        
        return true;
    }

    public async Task<bool> ForgotPassword(ForgotPasswordRequestDto request)
    {
        var user = await _usersRepository.GetByUsernameAsync(request.Email);

        if (user is null || request.Email != user.Email)
            throw new UnauthorizedException($"El usuario con el correo electrónico { request.Email } no existe.");

        //returns int
        await _passwordResetRepository.InvalidateUserTokensAsync(user.Id);

        var token = _jwtService.CreatePasswordResetToken();
        var requestUserByGuid = _clientInfoRepository.GetUserId();
        var currentTime = DateTime.UtcNow;

        if(requestUserByGuid is null)
            throw new UnauthorizedException("La petición no tiene un administrador.");

        var passwordReset = new PasswordReset
        {
            Id = Guid.CreateVersion7(),
            UserId = user.Id,
            RequestedByUserd = requestUserByGuid.Value,
            TokenHash = _jwtService.HashToken(token),
            CreatedAt = currentTime,
            ExpiresAt = currentTime.AddMinutes(30),
            UsedAt = null
        };

        //Guardar contraseña temporal
        var result = await _usersRepository.AddResetPassword(passwordReset);

        await _emailService.SendPassowrdRecoveryEmailAsync(user.Email, token);
        return true;
    }

    public async Task<bool> ResetPassword(ResetPasswordRequestDto request)
    {
        if(request.NewPassword != request.ConfirmNewPassword)
            throw new ValidationException("Las contraseñas no coinciden");

        var tokenHash = _jwtService.HashToken(request.Token);
        var passwordReset = await _passwordResetRepository.GetValidByTokenHashAsync(tokenHash);

        if (passwordReset is null)
            throw new UnauthorizedException("El token de recuperación no es válido.");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        passwordReset.User.PasswordHash = passwordHash;
        passwordReset.UsedAt = DateTime.UtcNow;

        await _passwordResetRepository.SaveChangesAsync();
        return true;
    }

    public async Task<AuthResponseDto> RefreshToken(RefreshTokenRequestDto request)
    {
        var token = await _tokenRepository.GetActiveRefreshTokenAsync(_jwtService.HashToken(request.RefreshToken));

        if(token is null || token.Revoked || token.ExpiresAt < DateTime.UtcNow)
            throw new UnauthorizedException("Refresh token inválido.");
        
        //Revoke token
        token.Revoked = true;
        var resultRevoke = await _tokenRepository.SaveChangesAsync();

        //Create new token
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
            CreatedByIp = _clientInfoRepository.GetClientIpAddress()
        };

        //Save Refresh Token
        var resultSave = await _tokenRepository.AddRefreshTokenAsync(refreshToken);

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