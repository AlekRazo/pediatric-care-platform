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

    public Task<User> AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsByUserAndEmailAsync(string username, string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsByUserAndPasswordAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetByKeywordAsync(string keyword)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Logout()
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}