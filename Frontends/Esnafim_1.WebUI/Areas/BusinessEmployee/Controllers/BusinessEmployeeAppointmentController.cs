using Esnafim_1.Dto.AppointmentsDtos;
using Esnafim_1.WebUI.Areas.BusinessEmployee.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.Json;

namespace Esnafim_1.WebUI.Areas.BusinessEmployee.Controllers
{
    [Area("BusinessEmployee")]
    [Route("BusinessEmployee/BusinessEmployeeAppointment")]
    public class BusinessEmployeeAppointmentController : BusinessEmployeeBaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BusinessEmployeeAppointmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var employeeId = HttpContext.Session.GetInt32("BusinessEmployeeId");
            if (employeeId == null || employeeId <= 0)
                return RedirectToAction("Login", "BusinessEmployeeAuth", new { area = "BusinessEmployee" });

            var client = _httpClientFactory.CreateClient("EsnafimApi");

            var url = $"api/Appointments/GetAppointmentsByEmployeeId/{employeeId.Value}";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                // İstersen burada TempData ile mesaj basarız
                return View(new BusinessEmployeeAppointmentIndexViewModel());
            }

            var json = await response.Content.ReadAsStringAsync();

            // Hem "liste" hem "tek obje" dönüşünü handle edelim:
            List<GetAppointmentByEmployeeIdDto> appointments;
            try
            {
                appointments = JsonSerializer.Deserialize<List<GetAppointmentByEmployeeIdDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
            }
            catch
            {
                var single = JsonSerializer.Deserialize<GetAppointmentByEmployeeIdDto>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                appointments = single != null ? new List<GetAppointmentByEmployeeIdDto> { single } : new();
            }

            // Sıralama / ayırma
            var now = DateTime.Now;

            DateTime GetStart(GetAppointmentByEmployeeIdDto a)
            {
                // appointmentTime: "17:00:00"
                var time = TimeSpan.TryParse(a.AppointmentTime, out var ts) ? ts : TimeSpan.Zero;
                return a.AppointmentDate.Date.Add(time);
            }

            var past = appointments
                .Where(a => GetStart(a) < now)
                .OrderByDescending(a => GetStart(a))
                .ToList();

            var future = appointments
                .Where(a => GetStart(a) >= now)
                .OrderBy(a => GetStart(a))
                .ToList();

            var vm = new BusinessEmployeeAppointmentIndexViewModel
            {
                Approved = future.Where(a => a.IsApproved).ToList(),
                Pending = future.Where(a => !a.IsApproved).ToList(),
                Past = past
            };

            return View(vm);
        }

        [HttpPost("Approve")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(ApproveAppointmentViewModel model)
        {
            var sessionEmployeeId = HttpContext.Session.GetInt32("BusinessEmployeeId");
            if (sessionEmployeeId == null || sessionEmployeeId <= 0)
                return RedirectToAction("Login", "BusinessEmployeeAuth", new { area = "BusinessEmployee" });

            model.EmployeeId = sessionEmployeeId.Value;

            var client = _httpClientFactory.CreateClient("EsnafimApi");

            var payload = new
            {
                appointmentId = model.AppointmentId,
                userId = model.UserId,
                businessId = model.BusinessId,
                employeeId = model.EmployeeId,
                appointmentDate = model.AppointmentDate,
                appointmentTime = model.AppointmentTime,
                note = model.Note ?? "",
                isApproved = true,
                approvedDate = DateTime.Now,   // ✅ otomatik
                customerArrive = model.CustomerArrive
            };

            var response = await client.PutAsJsonAsync("api/Appointments", payload);

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Randevu onaylanamadı. (API hata döndü)";
                return RedirectToAction("Index");
            }

            TempData["Success"] = $"Randevu #{model.AppointmentId} onaylandı.";
            return RedirectToAction("Index");
        }

    }
}
