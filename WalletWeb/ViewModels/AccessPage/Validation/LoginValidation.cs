using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using FluentValidation;

namespace WalletWeb.ViewModels.AccessPage.Validation
{
	public class LoginValidation : AbstractValidator<LoginViewModel>
    {
		public LoginValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is requierd.")
                                .EmailAddress().WithMessage("This is not valid email.")
                                .MinimumLength(10).WithMessage("dupadupa dupa");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is requierd.");
        }
    }
}
