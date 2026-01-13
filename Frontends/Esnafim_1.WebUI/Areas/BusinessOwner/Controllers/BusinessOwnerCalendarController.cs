using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.Controllers
{
    [Area("BusinessOwner")]
    [Route("BusinessOwner/BusinessOwnerCalendar")]
    public class BusinessOwnerCalendarController : Controller
    {
        // Takvim sayfası (businessId ile aç)
        [HttpGet("Index/{businessId:int}")]
        public IActionResult Index(int businessId)
        {
            ViewBag.BusinessId = businessId;
            return View();
        }

        // Takvim event'lerini dönen endpoint (şimdilik test verisi)
        [HttpGet("GetEvents")]
        public IActionResult GetEvents(int businessId, DateTime start, DateTime end)
        {
            var now = DateTime.Now;

            var events = new[]
            {
                new {
                    id = 2,
                    title = "Test Randevu (serverdan geldi)",
                    start = now.ToString("s"),
                    end = now.AddMinutes(30).ToString("s")
                }
            };

            return Json(events);
        }
    }
}
