using Microsoft.EntityFrameworkCore;
using ZephyrBet.Models.Entity;
using ZephyrBetAPI.Data;

namespace ZephyrBetAPI.Services.PlayerService;

public class PlayerService : IPlayerService
{
    private readonly DataContext _context;
    public PlayerService(DataContext context)
    {
        _context = context;
    }
    
    
    
    
    public async Task<List<Player>> GetAllPlayers()
    {
        var players = await _context.Players.ToListAsync();
        return players;
    }

    public async Task<Player?> GetPlayerById(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if(player == null)
        {
            return null;
        }
        
        return player;
    }

    public async Task<List<Player>> AddPlayer(Player player)
    {
        await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync();
        return await _context.Players.ToListAsync();
    }

    public async Task<List<Player>?> UpdatePlayer(Player request)
    {
        var player = await _context.Players.FindAsync(request.Id);
        if (player == null)
        {
            return null;
        }
        
        player.PasswordHash = request.PasswordHash;
        player.enabled = request.enabled;
        player.Balance = request.Balance;
        
        await _context.SaveChangesAsync();

        return await _context.Players.ToListAsync();
    }

    public async Task<List<Player>?> DeletePlayer(int id)
    {
        var player = await  _context.Players.FindAsync(id);
        if (player == null)
        {
            return null;
        }
        
        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
        return await _context.Players.ToListAsync();
    }
}