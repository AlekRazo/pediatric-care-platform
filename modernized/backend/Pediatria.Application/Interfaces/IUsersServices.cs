using Pediatria.Application.DTOs.Auth;
using Pediatria.Application.DTOs.Users;

namespace Pediatria.Application.Interfaces.Identity;

public interface IUsersService
{
    Task<AuthResponseDto> Login (AuthRequestDto request);
    Task<bool> RecoverPassword(PasswordRecoveryRequestDto request);
    Task<bool> Logout();
    Task<List<GetUsersResponseDto>> GetUsers(string keyword);
    Task<GetUserResponseDto> GetUser(Guid id);
    Task<RegisterUserResponseDto> RegisterUser(RegisterUserRequestDto request);
    Task<UpdateUserResponseDto> UpdateUser(UpdateUserRequestDto request);
    Task<bool> DeleteUser(Guid id);
}