using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnimalsWeb.Models
{
    
    public class LoginPage 
    {
        [Display(Name = "User Name :")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "wrong user name")]
        public string User { get; set; } = null!;

        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "wrong password")]

        public string Password { get; set; } = null!;
    }
}
