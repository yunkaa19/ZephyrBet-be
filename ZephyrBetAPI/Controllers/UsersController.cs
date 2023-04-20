using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using ZephyrBet.Models.Entity;
using ZephyrBetAPI.Services.UserService;

namespace ZephyrBetAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _usersService;
    
    public UsersController(IUserService userService)
    {
        _usersService = userService;
    }


    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        return await _usersService.GetAllUsers();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        User result = await _usersService.GetUserById(id);
        if (result == null)
        {
            return NotFound("User not found");
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<User>> AddUser(User user)
    {
        var result = await _usersService.AddUser(user);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<User>>> UpdateUser(User request)
    {
        var result = await _usersService.UpdateUser(request);
        if (result == null)
        {
            return NotFound("User not found");
        }

        return Ok(result);
        
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<User>>> DeleteUser(int id)
    {
        var result = await _usersService.DeleteUser(id);
        if (result == null)
        {
            return NotFound("User not found");
        }
        return Ok(result);
        
    }
}