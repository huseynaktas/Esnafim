using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStaticsComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
