using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WalletWeb.Controllers.Base;

namespace WalletWeb.Controllers
{
    public class SettingsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
