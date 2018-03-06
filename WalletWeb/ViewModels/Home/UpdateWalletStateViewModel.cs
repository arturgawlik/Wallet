using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WalletWeb.ViewModels.Home
{
    public class UpdateWalletStateViewModel
    {
        public decimal Change { get; set; }

        public bool IsPositive { get; set; }

        public int? WalletId { get; set; }

        public List<SelectListItem> WalletSelectListItems { get; set; }
    }
}