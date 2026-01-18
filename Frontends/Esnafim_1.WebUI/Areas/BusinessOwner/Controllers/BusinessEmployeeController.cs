using Esnafim_1.Dto.EmployeeDtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.Controllers
{
    [Area("BusinessOwner")]
    [Route("BusinessOwner/BusinessEmployee")]
    public class BusinessEmployeeController : Controller
    {
        private readonly HttpClient _httpClient;

        public BusinessEmployeeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("Index/{businessId:int}")]
        public async Task<IActionResult> Index(int businessId)
        {
            var url = $"https://localhost:7028/api/Employees/GetEmployeesByBusinessId/{businessId}";

            var employees = await _httpClient.GetFromJsonAsync<List<GetEmployeeByBusinessIdDto>>(url)
                           ?? new List<GetEmployeeByBusinessIdDto>();

            // İstersen businessId’yi view’de linklerde kullanmak için taşıyalım
            ViewBag.BusinessId = businessId;

            return View(employees);
        }
    }
}
