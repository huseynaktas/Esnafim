using Esnafim_1.Dto.AppointmentsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.Controllers
{
    [Area("BusinessOwner")]
    [Route("BusinessOwner/BusinessOwnerCalendar")]
    public class BusinessOwnerCalendarController : BusinessOwnerBaseController
    {

        private readonly HttpClient _httpClient;

        public BusinessOwnerCalendarController(IHttpClientFactory httpClientFactory): base(httpClientFactory) 
        {
            _httpClient = httpClientFactory.CreateClient("EsnafimApi");
        }

        // Takvim sayfası (businessId ile aç)
        [HttpGet("Index/{businessId:int}")]
        public IActionResult Index(int businessId)
        {
            ViewBag.BusinessId = businessId;
            return View();
        }

        [HttpGet("GetEvents")]
        public async Task<IActionResult> GetEvents(int businessId, DateTime start, DateTime end)
        {
            // API endpoint
            var apiUrl = $"https://localhost:7028/api/Appointments/GetAppointmentsByBusinessId/{businessId}";

            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
                return Json(new List<object>());

            var jsonData = await response.Content.ReadAsStringAsync();

            var appointments = JsonConvert.DeserializeObject<List<GetAppointmentCalendarDto>>(jsonData)
                   ?? new List<GetAppointmentCalendarDto>();

            // FullCalendar formatına map
            var events = appointments
                .Where(x => x.AppointmentDate >= start && x.AppointmentDate <= end)
                .Select(x =>
                {
                    var startDateTime = x.AppointmentDate.Date + x.AppointmentTime;

                    return new
                    {
                        id = x.AppointmentId,
                        title = x.IsApproved ? "Randevu (Onaylı)" : "Randevu (Beklemede)",
                        start = startDateTime.ToString("s"),
                        end = startDateTime.AddMinutes(30).ToString("s") // 🔥 sabit 30 dk
                    };
                });

            return Json(events);
        }

    }
}
