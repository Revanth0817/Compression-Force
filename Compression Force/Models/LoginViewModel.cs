using System.ComponentModel.DataAnnotations;

namespace Compression_Force.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Email { get; set; } // We will treat this as eRName from your DB

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}