using ZephyrBet.Models.Entity;

namespace ZephyrBet.Models.DTOs;

public class FullPlayerDTO : UserDTO
{
    private string Name { get; set; }
    private string Surname { get; set; }
    private DateTime Birthday { get; set; }
    private double Balance { get; set; }
    private double WinFactor { get; set; }
    private double LostBets { get; set; }
    private double WonBets { get; set; }

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