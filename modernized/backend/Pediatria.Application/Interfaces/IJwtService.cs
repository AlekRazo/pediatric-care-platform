using Pediatria.Domain.Entities.Users;

namespace Pediatria.Application.Interfaces;

public interface IJwtService
{
    Task<string> GenerateTokenAsync(User user);
}