using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZephyrBet.Models.DTOs;
using ZephyrBetAPI.Services.PlayerService;
using ZephyrBetAPI.Services.UserService;


namespace ZephyrBetAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public GameController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost("gameResult")]
        public async Task<ActionResult> RecordGameResult(GameResultDTO gameResult)
        {
            var player = await _playerService.GetPlayerById(Convert.ToInt32(gameResult.PlayerId));
            if (player == null)
            {
                return NotFound("Player not found");
            }

            switch (gameResult.boxiD)
            {
                case 1:
                    player.Balls++;
                    break;
                case 2:
                    player.Balance += 2;
                    break;
                case 3:
                    player.Balance += 3;
                    break;
                case 4:
                    player.Balance += 1.1;
                    break;
                case 5:
                    player.Balance += 1.5;
                    break;
                case 6:
                    player.Balance += 0.1;
                    break;
                case 7:
                    player.Balance += 0.5;
                    break;
            }

            _playerService.UpdatePlayer(player);

            return Ok(new { Balls = player.Balls, Balance = player.Balance });

        }
    }
}
