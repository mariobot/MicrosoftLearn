using System.ComponentModel.DataAnnotations;

namespace MultiTenancyByEnterprise.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Field required")]
        [EmailAddress(ErrorMessage = "Email not valid")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Field required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember me")]
        public bool Rememberme { get; set; }
    }
}
