using System.ComponentModel.DataAnnotations;

namespace WalletWeb.ViewModels.AccessPage
{
    public class LoginViewModel
    {
        [Required, EmailAddress, MaxLength(256), Display(Name = "Email")]
        public string Email { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }
        
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}