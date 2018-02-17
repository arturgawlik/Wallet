using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WalletWeb.Controllers
{
    public class AccessPageController : Controller
    {
        public IActionResult UiRegister()
        {
            return View();
        }
    }
}