namespace Pediatria.Domain.Interfaces;

public interface ITokenRepository
{
    string CreateJWTToken(User user);
}