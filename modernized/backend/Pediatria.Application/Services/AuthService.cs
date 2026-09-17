using Pediatria.Application.DTOs.Auth;
using Pediatria.Application.DTOs.Users;
using Pediatria.Application.Interfaces;
using Pediatria.Domain.Interfaces;

namespace Pediatria.Application.Services;

public class AuthService : IAuthService
{
    private readonly ITokenRepository _tokenRepository;

    public AuthService(ITokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
    }

    public Task<AuthResponseDto> Login(AuthRequestDto request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Logout()
    {
        throw new NotImplementedException();
    }

    public Task<bool> RecoverPassword(PasswordRecoveryRequestDto request)
    {
        throw new NotImplementedException();
    }
}