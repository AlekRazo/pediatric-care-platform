using Pediatria.Domain.Entities.Users;

namespace Pediatria.Application.Interfaces.Services;

public interface IJwtService
{
    string CreateJWTToken(User user);
    string CreateRefreshToken();
    string HashToken(string token);
}