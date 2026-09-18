using Pediatria.Domain.Entities.Users;

namespace Pediatria.Application.Interfaces.Repositories;

public interface ITokenRepository
{
    string CreateJWTToken(User user);
}