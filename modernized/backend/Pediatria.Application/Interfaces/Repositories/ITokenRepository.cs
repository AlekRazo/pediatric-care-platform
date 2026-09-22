using Pediatria.Domain.Entities.Users;

namespace Pediatria.Application.Interfaces.Repositories;

public interface ITokenRepository
{
    Task<int> AddRefreshTokenAsync(RefreshToken refreshToken);
    Task<RefreshToken?> GetActiveRefreshTokenAsync(string token);
    Task<int> RevokeRefreshTokenAsync(Guid id);
}