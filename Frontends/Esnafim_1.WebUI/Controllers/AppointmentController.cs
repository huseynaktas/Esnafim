using Esnafim_1.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Text.Json;

namespace Esnafim_1.WebUI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppointmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // ✅ Randevu alma ekranı
        // /Appointment/Create?businessId=2
        [HttpGet]
        public async Task<IActionResult> Create(int businessId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null || userId <= 0)
                return RedirectToAction("Login", "Auth");

            var client = _httpClientFactory.CreateClient("EsnafimApi");

            await FillDropdowns(client, businessId);

            var model = new CreateAppointmentViewModel
            {
                BusinessId = businessId,
                AppointmentDate = DateTime.Today
            };

            return View(model);
        }

        // ✅ Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAppointmentViewModel model)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null || userId <= 0)
                return RedirectToAction("Login", "Auth");

            var client = _httpClientFactory.CreateClient("EsnafimApi");

            // Dropdownlar postback'te kaybolmasın
            await FillDropdowns(client, model.BusinessId);

            if (!ModelState.IsValid)
                return View(model);

            // "11:30" -> TimeSpan
            if (!TimeSpan.TryParseExact(model.AppointmentTime, @"hh\:mm", CultureInfo.InvariantCulture, out var time))
            {
                ModelState.AddModelError("", "Saat formatı geçersiz.");
                return View(model);
            }

            // ✅ Çakışma kontrolü (UI'dan kaçsa bile burada yakala)
            var occupiedSlots = await GetOccupiedSlotsFromApi(client, model.BusinessId, model.EmployeeId, model.AppointmentDate);
            if (occupiedSlots.Contains(model.AppointmentTime))
            {
                ModelState.AddModelError("", "Seçtiğin saat dolu. Lütfen başka bir saat seç.");
                return View(model);
            }

            // ✅ Create payload
            var payload = new
            {
                userId = userId.Value,
                businessId = model.BusinessId,
                employeeId = model.EmployeeId,
                appointmentDate = model.AppointmentDate,
                appointmentTime = time,
                note = model.Note,
                isApproved = false,
                approvedDate = DateTime.MinValue,
                customerArrive = false
            };

            var response = await client.PostAsJsonAsync("api/Appointments", payload);

            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", $"Randevu oluşturulamadı. ({(int)response.StatusCode}) {errorBody}");
                return View(model);
            }

            TempData["Success"] = "Randevu talebin alındı. Onay sürecine gönderildi.";
            return RedirectToAction("UserProfile", "User");
        }

        // ✅ JS'in çağıracağı WebUI proxy endpoint
        // /Appointment/GetOccupiedSlots?businessId=2&employeeId=2&date=2026-01-16
        [HttpGet]
        public async Task<IActionResult> GetOccupiedSlots(int businessId, int employeeId, DateTime date)
        {
            var client = _httpClientFactory.CreateClient("EsnafimApi");
            var occupied = await GetOccupiedSlotsFromApi(client, businessId, employeeId, date);
            return Ok(occupied); // ["11:30","13:00"...]
        }

        // ----------------- Helpers -----------------

        private async Task FillDropdowns(HttpClient client, int businessId)
        {
            // ✅ Employees endpoint (senin mevcut çalışan endpointin)
            // https://localhost:7028/api/Employees/GetEmployeesByBusinessId/2
            var empResp = await client.GetAsync($"api/Employees/GetEmployeesByBusinessId/{businessId}");
            var empJson = await empResp.Content.ReadAsStringAsync();

            var employees = JsonSerializer.Deserialize<List<EmployeeDropdownDto>>(empJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<EmployeeDropdownDto>();

            ViewBag.Employees = employees
                .Select(x => new SelectListItem { Value = x.EmployeeId.ToString(), Text = x.Name })
                .ToList();

            // ✅ 10:00 - 20:00 arası 30 dk slotlar
            ViewBag.TimeSlots = GenerateTimeSlots30Min();
        }

        private static List<SelectListItem> GenerateTimeSlots30Min()
        {
            var list = new List<SelectListItem>();

            var start = new TimeSpan(10, 0, 0);
            var end = new TimeSpan(20, 0, 0);

            for (var t = start; t <= end; t = t.Add(TimeSpan.FromMinutes(30)))
            {
                var val = t.ToString(@"hh\:mm");
                list.Add(new SelectListItem { Value = val, Text = val });
            }

            return list;
        }

        private async Task<HashSet<string>> GetOccupiedSlotsFromApi(HttpClient client, int businessId, int employeeId, DateTime date)
        {
            var url = $"api/Appointments/OccupiedSlots?businessId={businessId}&employeeId={employeeId}&date={date:yyyy-MM-dd}";
            var resp = await client.GetAsync(url);

            if (!resp.IsSuccessStatusCode)
                return new HashSet<string>();

            var json = await resp.Content.ReadAsStringAsync();

            // API response: { "slots": ["11:30"] }
            var result = JsonSerializer.Deserialize<OccupiedSlotsResponseDto>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return new HashSet<string>(result?.Slots ?? new List<string>());
        }
    }

    // ✅ Employees dropdown DTO (API'nin döndürdüğü property isimleri bunlarla uyumlu olmalı)
    public class EmployeeDropdownDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
    }

    // ✅ OccupiedSlots response: { "slots": ["11:30"] }
    public class OccupiedSlotsResponseDto
    {
        public List<string> Slots { get; set; } = new();
    }
}
