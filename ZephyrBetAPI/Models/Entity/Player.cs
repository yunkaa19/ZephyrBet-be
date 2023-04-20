using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ZephyrBet.DataAnnotation;

namespace ZephyrBet.Models.Entity;

public class Player : User
{
    [Required(ErrorMessage = "Name is required")]
    [DisplayName("Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Surname is required")]
    [DisplayName("Surname")]
    public string Surname { get; set; }

    [Required(ErrorMessage = "Birthday is required")]
    [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [MinimumAge(18)]
    [DisplayName("Date of birth")]
    public DateTime Birthday { get; set; }

    public double Balance { get; set; }
    public double WinFactor { get; set; }

    public double LostBets { get; set; }
    public double WonBets { get; set; }
}