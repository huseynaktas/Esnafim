using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.ViewComponents.ServiceViewComponents
{
    public class _ServiceMainCoverComponentPartial: ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
