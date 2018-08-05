using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WalletDomain.Services.Interfaces;
using WalletWeb.Controllers.Base;
using WalletWeb.ViewModels.Home;

namespace WalletWeb.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IWalletService _walletService;

        public HomeController(IWalletService walletService)
        {
            _walletService = walletService;
        }
        
        [HttpGet]
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

        [HttpPost]
        public IActionResult AddMoney(HomeAgregateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.UpdateRevenues.WalletId.HasValue)
                {
                    var wallet = _walletService.GetWalletById(viewModel.UpdateRevenues.WalletId.Value);
                    wallet.Add(viewModel.UpdateRevenues.Change);
                }
                else
                {  
                    ModelState.AddModelError(null, "You need to specyfy wallet!");
                }
            }

            return View("Index", viewModel);
        }
        
        [HttpPost]
        public IActionResult SubstractMoney(HomeAgregateViewModel viewModel)
        {
            return Json("gg");
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

            return updateWalletStateViewModel;
        }

        private List<SelectListItem> initWalletList()
        {
            var result = (from w in _walletService.GetAll()
                select new SelectListItem()
                {
                    Text = w.Name,
                    Value = w.Id.ToString()
                }).ToList();

            return result;
        }
    }
}