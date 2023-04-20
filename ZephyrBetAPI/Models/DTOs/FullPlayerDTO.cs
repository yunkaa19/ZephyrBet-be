using ZephyrBet.Models.Entity;

namespace ZephyrBet.Models.DTOs;

public class FullPlayerDTO : UserDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public double Balance { get; set; }
    public double WinFactor { get; set; }
    public double LostBets { get; set; }
    public double WonBets { get; set; }

    public FullPlayerDTO()
    {
    }

    public FullPlayerDTO(int userID, string email, UserType type, string name, string surname, DateTime birthday,
        double balance, double winFactor, double lostBets, double wonBets) : base(userID, email, type)
    {
        Name = name;
        Surname = surname;
        Birthday = birthday;
        Balance = balance;
        WinFactor = winFactor;
        LostBets = lostBets;
        WonBets = wonBets;
    }
}