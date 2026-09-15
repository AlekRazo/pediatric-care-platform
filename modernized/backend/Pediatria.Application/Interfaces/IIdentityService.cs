namespace Pediatria.Application.Interfaces;

public interface IIdentityService
{
    Task<(bool Success, IEnumerable<string> Errors)> CreateUserAsync(User user, string password);
    Task<bool> AddToRoleAsync(User user, string role);
    Task<User?> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(User user, string password);
    Task<string> GetUserRoleAsync(User user);
}