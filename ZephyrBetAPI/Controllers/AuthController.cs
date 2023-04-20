using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ZephyrBet.Models.DTOs;
using ZephyrBet.Models.Entity;
using ZephyrBetAPI.Services.UserService;

namespace ZephyrBetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IConfiguration _configuration;
        
        private readonly IUserService _usersService;
    
        
        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _usersService = userService;
        }
        
        
        [HttpPost("register")]
        public ActionResult<User> Register(UserDTO request)
        {
            User? user = new User();
            user = _usersService.GetUserByEmail(request.Email).Result;
            if (user != null)
            {
                return BadRequest("User already exists");
            }
            else
            {

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
                user = new User
                {
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    Type = UserType.User
                };
                _usersService.AddUser(user);

                return Ok(user);
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
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Type.ToString())
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

    }
}
