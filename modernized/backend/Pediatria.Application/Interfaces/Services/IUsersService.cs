using Pediatria.Application.DTOs.Users;

namespace Pediatria.Application.Interfaces.Services;

public interface IUsersService
{
    

    //Search Users (USC-USR-004)
    Task<List<UserResponseDto>> GetUsers(string keyword);

    //Get User (USC-USR-005)
    Task<UserResponseDto> GetUser(Guid id);

    //Register User (USC-USR-006, USC-USR-007, USC-USR-008)
    Task<UserResponseDto> RegisterUser(RegisterUserRequestDto request);

    //Modify User (USC-USR-009, USC-USR-010, USC-USR-011)
    Task<UserResponseDto> UpdateUser(Guid id, UpdateUserRequestDto request);

    //Delete User (USC-USR-012)
    Task<bool> DeleteUser(Guid id);
}