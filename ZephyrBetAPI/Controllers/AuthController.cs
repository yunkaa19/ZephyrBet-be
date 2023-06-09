using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ZephyrBet.Models.DTOs;
using ZephyrBet.Models.Entity;
using ZephyrBetAPI.Services.AuthService;
using ZephyrBetAPI.Services.PlayerService;
using ZephyrBetAPI.Services.UserService;

namespace ZephyrBetAPI.Controllers
{
    [Route("Players/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        private readonly IUserService _usersService;
        private readonly IPlayerService _playerService;
    
        
        public AuthController(IConfiguration configuration, IUserService userService, IAuthService authService, IPlayerService playerService)
        {
            _configuration = configuration;
            _usersService = userService;
            _authService = authService;
            _playerService = playerService;
        }
        

        [HttpGet, Authorize]
        public ActionResult<string> GetAllData()
        {
            var userName = User?.Identity?.Name;
            var role = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            var userId = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value;
            var email = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            
            return Ok(new { userName, role, userId, email });
            
        }
        
        [HttpPost("decode")]
        public ActionResult<string> DecodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            var id = tokenS.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid).Value;
            return Ok(id);
        }
        
        
        //TODO: Send data to User Controller.
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(PlayerDTO request)
        {
            Player? player = new Player();
            player = (Player?)_usersService.GetUserByEmail(request.Email).Result;
            if (player != null)
            {
                return BadRequest("User already exists");
            }
            else
            {

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
                player = new Player()
                {
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    Type = UserType.User,
                    Name = request.Name,
                    Surname = request.Surname,
                    Birthday = request.Birthday,
                    
                    Balance = 0.00,
                    
                };
                var result = await _usersService.AddUser(player);
                
                string token = CreateToken(player);

                return Ok(new { user = result, token = token });
            }
        }
        
        [HttpPost("login")]
        public ActionResult<User> Login(UserDTO request)
        {
            
            User? user = new User();
            user = _usersService.GetUserByEmail(request.Email).Result;
            
            if (user == null)
            {
                return BadRequest("Invalid Details");
            }
            else if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Invalid Details");
            }
            
            string token = CreateToken(user);
            
            return Ok(token);
            
        }

        private string CreateToken(User user)
        {
            var player = _playerService.GetPlayerById(user.Id).Result;
            if (player == null)
            {
                var admin = _usersService.GetUserById(user.Id).Result;
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, admin.Type.ToString()),
                };
            

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );
            
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            if (player.Type == UserType.User)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, player.Id.ToString()),
                    new Claim(ClaimTypes.Email, player.Email),
                    new Claim(ClaimTypes.Role, player.Type.ToString()),
                    new Claim(ClaimTypes.Name, player.Name),
                };
            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
                );
            
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
            }
            else
            {
                User admin = player;
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, admin.Type.ToString()),
                };
            

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );
            
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
        }

    }
}
