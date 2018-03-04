using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WalletDomain.Domain;
using WalletDomain.Services.Interfaces;
using WalletWeb.ViewModels.Wallet;

namespace WalletWeb.Controllers
{
    [Authorize]
    public class WalletController : Controller
    {
        private readonly IWalletService walletService;
        private readonly UserManager<ApplicationUser> applicationUser;

        public WalletController(IWalletService walletService, UserManager<ApplicationUser> applicationUser)
        {
            this.applicationUser = applicationUser;
            this.walletService = walletService;

        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new HomeWalletViewModel();
            var currentUserId = Guid.Parse(applicationUser.GetUserId(User));
            var wallets = walletService.GetWalletsByUserId(currentUserId);

            var walletsViewModelList = (from w in wallets
                                        select new WalletViewModel()
                                        {
                                            Name = w.Name,
                                            State = w.State
                                        }).ToList();
            viewModel.Wallets = walletsViewModelList;

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var walletViewModel = new WalletViewModel();

            return View(walletViewModel);
        }

        [HttpPost]
        public IActionResult Add(WalletViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var wallet = new Wallet(viewModel.Name, viewModel.State.Value, Guid.Parse(applicationUser.GetUserId(User)));
                walletService.Create(wallet);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}