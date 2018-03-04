using System.ComponentModel.DataAnnotations;

namespace WalletWeb.ViewModels.Wallet
{
    public class WalletViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal? State { get; set; }
    }
}