using ZephyrBet.Models.Entity;

namespace ZephyrBet.Models.DTOs;

public class PlayerDTO : UserDTO
{
    private string Name { get; set; }
    private string Surname { get; set; }
    private DateTime Birthday { get; set; }
    private double Balance { get; set; }
    private double WinFactor { get; set; }

    public PlayerDTO()
    {
    }

    public PlayerDTO(int userID, string email, UserType type, string name, string surname, DateTime birthday,
        double balance, double winFactor) : base(userID, email, type)
    {
        Name = name;
        Surname = surname;
        Birthday = birthday;
        Balance = balance;
        WinFactor = winFactor;
    }
}