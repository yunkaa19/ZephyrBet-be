using Microsoft.Build.Framework;

namespace ZephyrBet.Models.DTOs;

public class EditPlayerDTO : EditUserDTO
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] private DateTime Birthday { get; set; }
}