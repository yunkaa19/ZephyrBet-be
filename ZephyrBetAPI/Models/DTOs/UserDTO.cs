using ZephyrBet.Models.Entity;

namespace ZephyrBet.Models.DTOs;

public class UserDTO
{
    private int UserID { get; set; }
    private string Email { get; set; }
    private UserType Type { get; set; }

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