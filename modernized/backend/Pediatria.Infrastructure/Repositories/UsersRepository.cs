using Microsoft.EntityFrameworkCore;
using Pediatria.Domain.Entities.Users;
using Pediatria.Domain.Interfaces;
using Pediatria.Infrastructure.Persistence;

namespace Pediatria.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly AppDbContext _context;

    public UsersRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return await _context.Users.AsNoTracking().Include(u => u.UserRoles).FirstAsync(u => u.Id == user.Id)!;
    }

    public Task<bool> DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> ExistsByUserAndEmailAsync(string username, string email)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username && u.Email == email)!;
    }

    public async Task<User?> ExistsByUserAndPasswordAsync(string username, string password)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password)!;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.AsNoTracking().Include(u => u.UserRoles).FirstOrDefaultAsync(u => u.Id == id)!;
    }

    public Task<List<User>> GetByKeywordAsync(string keyword)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Logout()
    {
        throw new NotImplementedException();
    }

    public async Task<User?> UpdateAsync(Guid id, User user)
    {
        var result = await _context.Users.AsNoTracking().Include(u => u.UserRoles).FirstOrDefaultAsync(u => u.Id == id)!;

        if(result is null) return null;

        result.Username = user.Username;
        result.Email = user.Email;
        result.PasswordHash = user.PasswordHash;
        result.Active =  user.Active;
        result.UserRoles =  user.UserRoles;

        return await _context.Users.AsNoTracking().Include(u => u.UserRoles).FirstOrDefaultAsync(u => u.Id == id)!;
    }
}