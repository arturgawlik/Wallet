using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WalletDomain.Services.Interfaces;
using WalletWeb.ViewModels.Home;

namespace WalletWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IWalletService _walletService;

        public HomeController(IWalletService walletService)
        {
            _walletService = walletService;
        }
        
        public IActionResult Index()
        {
            var viewModel = generateHomeAgregateViewModel();

            return View(viewModel);
        }

        private HomeAgregateViewModel generateHomeAgregateViewModel()
        {
            var viewModel = new HomeAgregateViewModel
            {
                UpdateOutgoings = initUpdateWalletState(false),
                UpdateRevenues = initUpdateWalletState(true)
            };
            return viewModel;
        }


        private UpdateWalletStateViewModel initUpdateWalletState(bool isIncome)
        {
            var updateWalletStateViewModel = new UpdateWalletStateViewModel()
            {
                Change = 0,
                IsPositive = isIncome,
                WalletId = null,
                WalletSelectListItems = initWalletList()
            };
        }

        private List<SelectListItem> initWalletList()
        {
            var result = (from w in _walletService.GetAll()
                select new SelectListItem()
                {
                    Text = w.Name,
                    Value = w.Id.ToString()
                });
        }
    }
}