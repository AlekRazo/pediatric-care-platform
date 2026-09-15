using Pediatria.Domain.Entities.Users;

namespace Pediatria.Domain.Interfaces;

public interface ITokenRepository
{
    string CreateJWTToken(User user);
}