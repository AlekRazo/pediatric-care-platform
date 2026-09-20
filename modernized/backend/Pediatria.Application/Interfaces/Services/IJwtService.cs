using Pediatria.Domain.Entities.Users;

namespace Pediatria.Application.Interfaces.Services;

public interface IJwtService
{
    Task<string> GenerateTokenAsync(User user);
}