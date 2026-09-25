using Microsoft.EntityFrameworkCore;
using Pediatria.Application.Interfaces.Repositories;
using Pediatria.Domain.Entities.Users;
using Pediatria.Infrastructure.Persistence;

namespace Pediatria.Infrastructure.Repositories;

public class PasswordResetRepository : IPasswordResetRepository
{
    private readonly AppDbContext _context;

    public PasswordResetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(PasswordReset passwordReset)
    {
        await _context.PasswordResets.AddAsync(passwordReset);
        return await _context.SaveChangesAsync();
    }

    public async Task<PasswordReset?> GetValidByTokenHashAsync(string tokenHash)
    {
        return await _context.PasswordResets.Include(pr => pr.User).FirstOrDefaultAsync(pr => pr.TokenHash == tokenHash && pr.UsedAt == null && pr.ExpiresAt > DateTime.UtcNow);
    }

    public async Task<int> InvalidateUserTokensAsync(Guid userId)
    {
        var tokens = await _context.PasswordResets.Where(pr => pr.UserId == userId && pr.UsedAt == null && pr.ExpiresAt > DateTime.UtcNow).ToListAsync();
        tokens.ForEach(t => t.UsedAt = DateTime.UtcNow);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}