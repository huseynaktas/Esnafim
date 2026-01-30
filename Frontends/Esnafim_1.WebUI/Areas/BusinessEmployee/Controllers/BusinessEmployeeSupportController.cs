using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Areas.BusinessEmployee.Controllers
{
    [Area("BusinessEmployee")]
    [Route("BusinessEmployee/BusinessEmployeeSupport")]
    public class BusinessEmployeeSupportController : Controller
    {
        [Route("Help")]
        public IActionResult Help() => View();

        [Route("Faq")]
        public IActionResult Faq() => View();

        [Route("Feedback")]
        public IActionResult Feedback() => View();
    }
}
