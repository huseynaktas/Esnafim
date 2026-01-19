using Esnafim_1.Dto.AppointmentsDtos;
using Esnafim_1.WebUI.Areas.BusinessOwner.ViewModels.BusinessOwnerAppointmentVM;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.Controllers
{
    [Area("BusinessOwner")]
    [Route("BusinessOwner/BusinessAppointment")]
    public class BusinessAppointmentController : BusinessOwnerBaseController
    {
        private readonly HttpClient _httpClient;

        public BusinessAppointmentController(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
            // ✅ Named client: "EsnafimApi"
            _httpClient = httpClientFactory.CreateClient("EsnafimApi");
        }


        [Route("Index")]
        [HttpGet("Index/{businessId:int}")]
        public async Task<IActionResult> Index(int businessId)
        {
            var url = $"https://localhost:7028/api/Appointments/GetAppointmentsByBusinessId/{businessId}";

            var appointments = await _httpClient.GetFromJsonAsync<List<GetAppointmentListDto>>(url)
                              ?? new List<GetAppointmentListDto>();

            var now = DateTime.Now;

            var vm = new BusinessAppointmentIndexViewModel
            {
                Past = appointments
                    .Where(x => x.StartDate < now)
                    .OrderByDescending(x => x.StartDate)
                    .ToList(),

                Pending = appointments
                    .Where(x => x.StartDate >= now && !x.IsApproved)
                    .OrderBy(x => x.StartDate)
                    .ToList(),

                Approved = appointments
                    .Where(x => x.StartDate >= now && x.IsApproved)
                    .OrderBy(x => x.StartDate)
                    .ToList(),
            };

            return View(vm);
        }

    }
}