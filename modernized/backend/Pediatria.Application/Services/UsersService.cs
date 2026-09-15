using Pediatria.Application.DTOs.Auth;
using Pediatria.Application.DTOs.Users;
using Pediatria.Application.Interfaces;
using Pediatria.Domain.Interfaces;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public Task<bool> DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponseDto> GetUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserResponseDto>> GetUsers(string keyword)
    {
        throw new NotImplementedException();
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

    public Task<UserResponseDto> RegisterUser(RegisterUserRequestDto request)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponseDto> UpdateUser(Guid id, UpdateUserRequestDto request)
    {
        throw new NotImplementedException();
    }
}