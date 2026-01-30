using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.Controllers
{
    [Area("BusinessOwner")]
    [Route("BusinessOwner/BusinessOwnerSupport")]
    public class BusinessOwnerSupportController : Controller
    {
        [Route("Help")]
        public IActionResult Help() => View();

        [Route("Faq")]
        public IActionResult Faq() => View();

        [Route("Feedback")]
        public IActionResult Feedback() => View();

    }
}
