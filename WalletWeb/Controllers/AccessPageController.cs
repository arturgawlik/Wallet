using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WalletWeb.ViewModels;
using Microsoft.AspNetCore.Identity;
using WalletDomain.Domain;

namespace WalletWeb.Controllers
{
    public class AccessPageController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccessPageController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() 
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email
                };

                var result = await userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}