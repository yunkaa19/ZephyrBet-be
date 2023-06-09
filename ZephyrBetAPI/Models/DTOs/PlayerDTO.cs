using ZephyrBet.Models.Entity;

namespace ZephyrBet.Models.DTOs;

public class PlayerDTO : UserDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    

    public PlayerDTO()
    {
    }

    public PlayerDTO(int userID, string email, UserType type, string name, string surname, DateTime birthday
        ) : base(userID, email, type)
    {
        Name = name;
        Surname = surname;
        Birthday = birthday;
        
    }
}