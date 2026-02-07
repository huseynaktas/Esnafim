using Esnafim_1.Dto.EmployeeDtos;
using Esnafim_1.WebUI.Areas.BusinessEmployee.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Areas.BusinessEmployee.Controllers
{
    [Area("BusinessEmployee")]
    [Route("BusinessEmployee/BusinessEmployeeProfile")]
    public class BusinessEmployeeProfileController : BusinessEmployeeBaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BusinessEmployeeProfileController(IHttpClientFactory httpClientFactory)
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

            var employee = await client.GetFromJsonAsync<GetEmployeeByIdDto>($"api/Employees/{employeeId.Value}");
            if (employee == null)
            {
                TempData["Error"] = "Çalışan bilgileri alınamadı.";
                return View(new BusinessEmployeeProfileViewModel());
            }

            // Navbar için isim session’a
            if (!string.IsNullOrWhiteSpace(employee.Name))
                HttpContext.Session.SetString("BusinessEmployeeName", employee.Name ?? "");


            var vm = new BusinessEmployeeProfileViewModel
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                RegistrationDate = employee.RegistrationDate,
                ImageUrl = employee.ImageUrl,
                NewImageUrl = employee.ImageUrl ?? ""
            };

            return View(vm);
        }

        [HttpPost("UpdateImage")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateImage(BusinessEmployeeProfileViewModel model)
        {
            var employeeId = HttpContext.Session.GetInt32("BusinessEmployeeId");
            if (employeeId == null || employeeId <= 0)
                return RedirectToAction("Login", "BusinessEmployeeAuth", new { area = "BusinessEmployee" });

            // Sadece link alanını validate ediyoruz
            if (!ModelState.IsValid)
                return await Index();

            var client = _httpClientFactory.CreateClient("EsnafimApi");

            // Endpoint tüm alanları istiyor diye önce mevcut çalışanı çekiyoruz
            var employee = await client.GetFromJsonAsync<GetEmployeeByIdDto>($"api/Employees/{employeeId.Value}");
            if (employee == null)
            {
                TempData["Error"] = "Çalışan bilgileri alınamadı. Güncelleme yapılamadı.";
                return RedirectToAction("Index");
            }

            // Sadece ImageUrl değişsin
            employee.ImageUrl = model.NewImageUrl;

            // PUT full update
            var putResponse = await client.PutAsJsonAsync("api/Employees", employee);
            if (!putResponse.IsSuccessStatusCode)
            {
                TempData["Error"] = "Fotoğraf güncellenemedi. (API hata döndü)";
                return RedirectToAction("Index");
            }

            TempData["Success"] = "Profil fotoğrafı güncellendi.";
            return RedirectToAction("Index");
        }

    }
}
