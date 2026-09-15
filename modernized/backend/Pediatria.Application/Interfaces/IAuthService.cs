using Pediatria.Application.DTOs.Auth;
using Pediatria.Application.DTOs.Users;

namespace Pediatria.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> Login(AuthRequestDto request);
    Task<bool> Logout();
    Task<bool> RecoverPassword(PasswordRecoveryRequestDto request);
}