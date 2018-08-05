using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WalletWeb.Controllers.Base
{
    [Authorize]
	public abstract class BaseController : Controller
	{
        //settingup current logged username - todo => this is called by every request - cant setup it ones??
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Username = User.Identity.Name;
            base.OnActionExecuting(filterContext);
        }
	}
}
