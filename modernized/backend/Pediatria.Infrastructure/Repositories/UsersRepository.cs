using Microsoft.EntityFrameworkCore;
using Pediatria.Application.Interfaces.Repositories;
using Pediatria.Domain.Entities.Users;
using Pediatria.Infrastructure.Persistence;

namespace Pediatria.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly AppDbContext _context;

    public UsersRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        return await _context.SaveChangesAsync();
    }

    public void DeleteUser(User user)
    {
        _context.Users.Remove(user);
    }

    //# 2 - Password Recovery (USC-USR-002)
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email)!;
    }

    public async Task<bool> ExistsByUsernameAsync(string username)
    {
        return await _context.Users.AnyAsync(u => u.Username == username)!;
    }

    //Login (USC-USR-001)
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users.AsNoTracking().Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.Username == username)!;
    }

    //# 5 - Get User (USC-USR-005)
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.AsNoTracking().Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.Id == id)!;
    }

    //# 4 - Search Users (USC-USR-004)
    public async Task<List<User>> GetByKeywordAsync(string keyword)
    {
        return await _context.Users.Where(u => u.Username.Contains(keyword) || u.Email.Contains(keyword)).ToListAsync();
    }

    //# 3 - Logout (USC-USR-003)
    public async Task<int> RevokeTokens(Guid id)
    {
        var tokens = await _context.RefreshTokens.Where(t => t.UserId == id && !t.Revoked).ToListAsync();
        tokens.ForEach(t => t.Revoked = true);
        return await _context.SaveChangesAsync();
    }

    public async Task<User?> UpdateAsync(Guid id, User user)
    {
        var result = await _context.Users.Include(u => u.UserRoles).FirstOrDefaultAsync(u => u.Id == id)!;

        if (result is null) return null;

        result.Username = user.Username;
        result.Email = user.Email;
        result.PasswordHash = user.PasswordHash;
        result.Active =  user.Active;

        result.UserRoles.Clear();

        foreach(var ur in user.UserRoles)
            result.UserRoles.Add(ur);

        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<User?> GetTrackedByIdAsync(Guid id)
    {
        return await _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.Id == id)!;
    }

    //User Roles
    public async Task<List<Role>> GetRolesByNamesAsync(IEnumerable<string> names)
    {
        return await _context.Roles.Where(r => names.Contains(r.Name)).ToListAsync();
    }
    
    //Password Reset
    public async Task<int> AddResetPassword(PasswordReset passwordReset)
    {
        await _context.PasswordResets.AddAsync(passwordReset);
        return await _context.SaveChangesAsync();
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}