using Microsoft.Build.Framework;

namespace ZephyrBet.Models.DTOs;

public class EditPlayerDTO : EditUserDTO
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public DateTime Birthday { get; set; }
}