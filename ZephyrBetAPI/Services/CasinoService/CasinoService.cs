using ZephyrBet.Models.Entity;
using ZephyrBetAPI.Data;

namespace ZephyrBetAPI.Services.CasinoService;

public class CasinoService : ICasinoService
{
    
    private readonly DataContext _context;
    public CasinoService(DataContext context)
    {
        _context = context;
    }
    public async Task<Casino> GetCasinoById(int id = 1)
    {
        var casino = await _context.Casino.FindAsync(id);
        return casino;
    }
}
