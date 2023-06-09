using ZephyrBet.Models.Entity;

namespace ZephyrBetAPI.Services.CasinoService;

public interface ICasinoService
{ 
    Task<Casino> GetCasinoById(int id);
}