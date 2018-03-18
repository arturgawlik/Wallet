using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WalletDomain.Domain;
using WalletDomain.Services.Interfaces;
using WalletInfrastructure.AbstractionImplementation;
using WalletWeb.ViewModels.Wallet;

namespace WalletWeb.Controllers
{
    [Authorize]
    public class WalletController : Controller
    {
        private readonly IWalletService _walletService;
        private readonly UserManager<ApplicationUser> _applicationUser;

        public WalletController(IWalletService walletService, UserManager<ApplicationUser> applicationUser)
        {
            this._applicationUser = applicationUser;
            this._walletService = walletService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new HomeWalletViewModel();
            var currentUserId = Guid.Parse(_applicationUser.GetUserId(User));
            var wallets = _walletService.GetWalletsByUserId(currentUserId);

            var walletsViewModelList = (from w in wallets
                                        select new WalletViewModel()
                                        {
                                            Id = w.Id,
                                            Name = w.Name,
                                            State = w.State
                                        }).OrderByDescending(x => x.Id).ToList();
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
                var wallet = new Wallet(viewModel.Name, viewModel.State.Value, Guid.Parse(_applicationUser.GetUserId(User)));
                _walletService.Create(wallet);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}