using System.ComponentModel.Design.Serialization;
using System.IO.Pipelines;
using System.Runtime.CompilerServices;
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

    public async Task<UserResponseDto> GetUser(Guid id)
    {
        var user = await _usersRepository.GetByIdAsync(id);

        if (user is null)
            throw new NotFoundException($"No existe el ususario con el id {id}.");

        return Map(user);
    }

    public async Task<List<UserResponseDto>> GetUsers(string keyword)
    {
        var users = await _usersRepository.GetByKeywordAsync(keyword);
        return users.Select(x => Map(x)).ToList();
    }

    public async Task<UserResponseDto> RegisterUser(RegisterUserRequestDto request)
    {
        List<string> errors = new List<string>();

        if (string.IsNullOrEmpty(request.Email))
            errors.Add("El correo es obligatorio.");

        if (string.IsNullOrEmpty(request.Password))
            errors.Add("La contraseña es obligatoria.");
        
        if (string.IsNullOrEmpty(request.Username))
            errors.Add("El nombre de usuario es obligatorio.");

        if (errors.Count > 0)
            throw new ValidationException("Existen valores de usuario faltantes.", errors);

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

        if (result == 0)
            throw new Exception($"No se pudo registrar el usuario con el id {user.Id}. SaveChanges no afectó ninguna fila.");
        
        var newUser = await _usersRepository.GetByIdAsync(user.Id);

        //Edge case: Register is successful, but the context couldn't get the user back.
        if (newUser is null)
            throw new Exception($"El usuario con el id {user.Id} se registró, pero no pudo recuperarse.");

        return Map(newUser);
    }

    public async Task<UserResponseDto> UpdateUser(Guid id, UpdateUserRequestDto request)
    {
        var user = await _usersRepository.GetTrackedByIdAsync(id);

        if (user is null)
            throw new NotFoundException($"No existe el ususario con el id {id}.");

        user.Username = !string.IsNullOrEmpty(request.Username) ? request.Username : user.Username;
        user.Email = !string.IsNullOrEmpty(request.Email) ? request.Email : user.Email;
        user.PasswordHash = !string.IsNullOrEmpty(request.NewPassword) ? BCrypt.Net.BCrypt.HashPassword(request.NewPassword) : user.PasswordHash;
        user.Active = request.Active.HasValue ? request.Active.Value : user.Active;

        if (request.Roles is not null && request.Roles.Count > 0){
            var userRoles = await _usersRepository.GetRolesByNamesAsync(request.Roles);
            var invalidRoles = request.Roles.Except(userRoles.Select(r => r.Name)).ToList();

            if (invalidRoles.Count > 0)
                throw new BusinessException($"Los siguientes roles no existen: {string.Join(", ", invalidRoles)}.");
            
            user.UserRoles.Clear();

            foreach(var role in userRoles)
                user.UserRoles.Add(new UserRole{ UserId = user.Id, RoleId = role.Id });
        }
        
        await _usersRepository.SaveChangesAsync();
        
        return Map(user);
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var user = await _usersRepository.GetTrackedByIdAsync(id);

        if (user is null)
            throw new NotFoundException($"No existe el ususario con el id {id}.");

        _usersRepository.DeleteUser(user);
        await _usersRepository.SaveChangesAsync();
        
        return true;
    }

    private UserResponseDto Map(User user)
    {
        return new UserResponseDto
        {
            Id = user.Id,
            Username =  user.Username,
            Email = user.Email,
            IsActive = user.Active,
            Roles = user.UserRoles is not null ? user.UserRoles.Select(ur => ur.Role.Name).ToList() : new List<string>(),
            CreatedAt = user.CreatedAt
        };
    }
}