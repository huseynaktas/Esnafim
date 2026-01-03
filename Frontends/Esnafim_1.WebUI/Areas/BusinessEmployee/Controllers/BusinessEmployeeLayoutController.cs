using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Areas.BusinessEmployee.Controllers
{
    public class BusinessEmployeeLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult BusinessEmployeeHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult BusinessEmployeeNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult BusinessEmployeeSidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult BusinessEmployeeFooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult BusinessEmployeeScriptPartial()
        {
            return PartialView();
        }
        public PartialViewResult BusinessEmployeePluginsCssLinkPartial()
        {
            return PartialView();
        }
        public PartialViewResult BusinessEmployeeDataTablesCssLinkPartial()
        {
            return PartialView();
        }
    }
}
