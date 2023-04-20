using Microsoft.EntityFrameworkCore;
using ZephyrBet.Models.Entity;
using ZephyrBetAPI.Data;

namespace ZephyrBetAPI.Services.UserService;

public class UserService : IUserService
{

    private readonly DataContext _context;
    public UserService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<User>> GetAllUsers()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<User?> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if(user == null)
        {
            return null;
        }
        
        return  user;
    }

    public async Task<List<User>> AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return await _context.Users.ToListAsync();
    }

    public async Task<List<User>?> UpdateUser(User request)
    {
        var User = await _context.Users.FindAsync(request.Id);
        if (User == null)
        {
            return null;
        }
        User.Email = request.Email;
        User.PasswordHash = request.PasswordHash;
        User.Type = request.Type;
        User.enabled = request.enabled;
        
        await _context.SaveChangesAsync();

        return await _context.Users.ToListAsync();
    }
    //TODO: Wrapper object to controller to know if user was deleted or not found (Status codes)
    public async Task<List<User>?> DeleteUser(int id)
    {
        var user = await  _context.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return await _context.Users.ToListAsync();
    }


    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            return null;
        }
        return user;
    }
}