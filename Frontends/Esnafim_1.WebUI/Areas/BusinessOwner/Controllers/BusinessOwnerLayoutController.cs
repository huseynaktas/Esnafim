using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.Controllers
{
    public class BusinessOwnerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult BusinessOwnerHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult BusinessOwnerNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult BusinessOwnerSidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult BusinessOwnerFooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult BusinessOwnerScriptPartial()
        {
            return PartialView();
        }
        public PartialViewResult BusinessOwnerPluginsCssLinkPartial()
        {
            return PartialView();
        }
        public PartialViewResult BusinessOwnerDataTablesCssLinkPartial()
        {
            return PartialView();
        }
    }
}
