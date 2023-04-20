using ZephyrBet.Models.Entity;

namespace ZephyrBet.Models.DTOs;

public class UserDTO
{
    public int UserID { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    
    public UserType Type { get; set; }

    public UserDTO(string email, string password)
    {
        Email = email;
        Password = password;
    }
    
    public UserDTO()
    {
    }

    public UserDTO(int userID, string email, UserType type)
    {
        UserID = userID;
        Email = email;
        Type = type;
    }
}