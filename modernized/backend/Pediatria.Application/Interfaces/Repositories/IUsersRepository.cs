using Pediatria.Domain.Entities.Users;

namespace Pediatria.Application.Interfaces.Repositories;

public interface IUsersRepository
{
    // Login (USC-USR-001)
    Task<bool> ExistsByUsernameAsync(string username);

    Task<User?> GetByUsernameAsync(string username);

    //Password Recovery (USC-USR-002)
    Task<User?> GetByEmailAsync(string email);

    //Logout (USC-USR-003)
    Task<int> RevokeTokens(Guid id);

    //Search Users (USC-USR-004)
    Task<List<User>> GetByKeywordAsync(string keyword);

    //Get User (USC-USR-005)
    Task<User?> GetByIdAsync(Guid id);

    //Register User (USC-USR-006, USC-USR-007, USC-USR-008)
    Task<int> AddAsync(User user);

    //Modify User (USC-USR-009, USC-USR-010, USC-USR-011)
    Task<User?> UpdateAsync(Guid id, User user);

    //Delete User (USC-USR-012)
    void DeleteUser(User user);

    //User Roles
    Task<List<Role>> GetRolesByNamesAsync(IEnumerable<string> names);

    Task<User?> GetTrackedByIdAsync(Guid id);

    //Reset Password
    Task<int> AddResetPassword(PasswordReset passwordReset);

    Task<int> SaveChangesAsync();

    
}