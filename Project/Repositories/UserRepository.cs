using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Project.Models;

namespace Project.Repositories;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => EF.Functions.Like(u.Email, $"%{email}%"));
    }

    public async Task<User> CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserAsync(int id, User user)
    {
        var existingUser = await GetUserByIdAsync(id);
        if (existingUser == null || existingUser.IsDeleted == 1 ) return null;

        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        _context.Users.Update(existingUser);
        await _context.SaveChangesAsync();
        return existingUser;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await GetUserByIdAsync(id);
        if (user == null) return false;

        user.IsDeleted = 1;
        await _context.SaveChangesAsync();
        return true;
    }
}
