using System.ComponentModel.DataAnnotations;

namespace WalletWeb.ViewModels.AccessPage
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }
        
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}