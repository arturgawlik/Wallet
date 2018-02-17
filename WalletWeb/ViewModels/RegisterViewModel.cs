using System;
using System.ComponentModel.DataAnnotations;

namespace WalletWeb.ViewModels
{
    public class RegisterViewModel
    {
        [Required, EmailAddress, MaxLength(256), Display(Name = "Email")]
        public string Email { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password does not match the confirmation password.")]
        public string ConfirmPassword { get; set; }

        public string Firstname { get; set; }

        public string Secondname { get; set; }

        public DateTime? BrithdayDate { get; set; }


    }
}