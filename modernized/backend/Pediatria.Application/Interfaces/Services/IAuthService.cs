using Pediatria.Application.DTOs.Auth;
using Pediatria.Application.DTOs.Users;

namespace Pediatria.Application.Interfaces.Services;

public interface IAuthService
{
    // Login (USC-USR-001)
    Task<AuthResponseDto> Login (AuthRequestDto request);

    //Password Recovery (USC-USR-002)
    Task<bool> ForgotPassword(ForgotPasswordRequestDto request);

    Task<bool> ResetPassword(ResetPasswordRequestDto request);

    //Logout (USC-USR-003)
    Task<bool> Logout();

    Task<AuthResponseDto> RefreshToken(RefreshTokenRequestDto request);
}