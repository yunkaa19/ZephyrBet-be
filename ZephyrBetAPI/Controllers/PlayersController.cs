using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZephyrBet.Models.Entity;
using ZephyrBetAPI.Services.PlayerService;

namespace ZephyrBetAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Player>>> GetAllPlayers()
        {
            return await _playerService.GetAllPlayers();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            Player result = await _playerService.GetPlayerById(id);
            if (result == null)
            {
                return NotFound("Player not found");
            }
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<ActionResult<Player>> AddPlayer(Player player)
        {
            var result = await _playerService.AddPlayer(player);
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Player>>> UpdatePlayer(Player request)
        {
            var result = await _playerService.UpdatePlayer(request);
            if (result == null)
            {
                return NotFound("Player not found");
            }

            return Ok(result);
            
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Player>>> DeletePlayer(int id)
        {
            var result = await _playerService.DeletePlayer(id);
            if (result == null)
            {
                return NotFound("Player not found");
            }

            return Ok(result);
        }
        
        
    }
}
