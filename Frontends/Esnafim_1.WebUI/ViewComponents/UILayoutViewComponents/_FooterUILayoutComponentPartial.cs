using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
