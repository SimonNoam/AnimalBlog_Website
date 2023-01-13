using System.ComponentModel.DataAnnotations;

namespace AnimalsWeb.Models
{
    public class RegisterPage
    {
        [Required]
        [Display(Name = "User Name")]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
