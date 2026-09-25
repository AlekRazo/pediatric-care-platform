using Pediatria.Domain.Entities.Users;

namespace Pediatria.Application.Interfaces.Repositories;

public interface IPasswordResetRepository
{
    Task <int> AddAsync(PasswordReset passwordReset);
    Task<PasswordReset?> GetValidByTokenHashAsync(string tokenHash);
    Task<int> InvalidateUserTokensAsync(Guid userId);
    Task<int> SaveChangesAsync();
}