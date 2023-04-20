using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ZephyrBet.Models.Entity;

namespace ZephyrBet.Models.DTOs;

public class EditUserDTO
{
    private int UserID;
    private UserType Type;

    [Required]
    [DisplayName("Email Address")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [DisplayName("Password")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; }

    public EditUserDTO()
    {
    }

    public EditUserDTO(int userId, UserType type, string email, string password)
    {
        UserID = userId;
        Type = type;
        Email = email;
        Password = password;
    }

    public EditUserDTO(EditPlayerDTO editPlayerDto)
    {
        UserID = editPlayerDto.UserID;
        Type = editPlayerDto.Type;
        Email = editPlayerDto.Email;
        Password = editPlayerDto.Password;
    }
}