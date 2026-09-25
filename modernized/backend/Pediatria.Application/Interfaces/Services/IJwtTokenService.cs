using Pediatria.Domain.Entities.Users;

namespace Pediatria.Application.Interfaces.Services;

public interface IJwtTokenService
{
    string CreateJWTToken(User user);
    string CreateRefreshToken();
    string HashToken(string token);
    string CreatePasswordResetToken();
}