using System.ComponentModel.DataAnnotations;

namespace ZephyrBet.Models.DTOs;

public class BetDTO
{
    [Required] [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    private double amount;
}