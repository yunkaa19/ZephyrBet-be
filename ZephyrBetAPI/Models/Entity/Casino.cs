using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ZephyrBet.Models.Entity;


public class Casino
{
    public int Id { get; set; } = 1;
    public double Funds {get; set;}
    public double Jackpot {get; set;}
    public double WinCoefficient {get; set;}
}