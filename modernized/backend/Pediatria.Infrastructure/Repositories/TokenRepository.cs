using Microsoft.EntityFrameworkCore;
using Pediatria.Application.Interfaces.Repositories;
using Pediatria.Domain.Entities.Users;
using Pediatria.Infrastructure.Persistence;

namespace Pediatria.Infrastructure.Repositories;

public class TokenRepository : ITokenRepository
{
    AppDbContext _context;

    public TokenRepository (AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddRefreshTokenAsync(RefreshToken refreshToken)
    {
        await _context.RefreshTokens.AddAsync(refreshToken);
        return await _context.SaveChangesAsync();
    }

    public async Task<RefreshToken?> GetActiveRefreshTokenAsync(string token)
    {
        return await _context.RefreshTokens.Include(rt => rt.User).FirstOrDefaultAsync(rt => rt.TokenHash == token);
    }

    public async Task<int> RevokeAllRefreshTokensAsync(Guid userId)
    {
        var tokens = await _context.RefreshTokens.Where(t => t.UserId == userId && !t.Revoked).ToListAsync();
        tokens.ForEach(t => t.Revoked = true);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}