using FluentValidation;

namespace WalletWeb.ViewModels.Wallet.Validation
{
    public class WalletValidator : AbstractValidator<WalletViewModel>
    {
        public WalletValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Wallet name can not be empty.");

            RuleFor(x => x.State).NotEmpty().WithMessage("State can not be empty.")
                .GreaterThanOrEqualTo(0M).WithMessage("Wallet starting state must be greater or equal to 0.");
        }
    }
}