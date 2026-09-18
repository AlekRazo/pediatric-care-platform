using Pediatria.Application.DTOs.Auth;
using Pediatria.Application.DTOs.Users;
using Pediatria.Application.Interfaces.Repositories;
using Pediatria.Application.Interfaces.Services;
using Pediatria.Domain.Entities.Users;
using Pediatria.Domain.Exceptions;

namespace Pediatria.Application.Services;

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

    public async Task<UserResponseDto> RegisterUser(RegisterUserRequestDto request)
    {
        var exists = await _usersRepository.ExistsByUsernameAsync(request.Username);

        if (exists)
            throw new BusinessException("El usuario ya se encuentra registrado.");

        var user = new User
        {
            Id = Guid.CreateVersion7(),
            Username = request.Username,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        int result = await _usersRepository.AddAsync(user);

        if(result > 0){
            var newUser = await _usersRepository.GetByIdAsync(user.Id);

            if(newUser is not null)
            {
                return new UserResponseDto
                {
                    Id = newUser.Id,
                    Username =  newUser.Username,
                    Email = newUser.Email,
                    IsActive = newUser.Active,
                    CreatedAt = newUser.CreatedAt
                };
            }
        }

        return new UserResponseDto();
    }

    public Task<UserResponseDto> UpdateUser(Guid id, UpdateUserRequestDto request)
    {
        throw new NotImplementedException();
    }
}