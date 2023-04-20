using ZephyrBet.Models.Entity;

namespace ZephyrBetAPI.Services.PlayerService;

public interface IPlayerService
{
    Task<List<Player>> GetAllPlayers();
    Task<Player?> GetPlayerById(int id);
    Task<List<Player>> AddPlayer(Player user);
    Task<List<Player>?> UpdatePlayer(Player request);
    Task<List<Player>?> DeletePlayer(int id);
}