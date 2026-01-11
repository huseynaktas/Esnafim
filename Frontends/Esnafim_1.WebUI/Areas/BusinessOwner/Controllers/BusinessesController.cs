using Esnafim_1.Dto.BusinessOwnerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.Controllers
{
    [Area("BusinessOwner")]
    [Route("BusinessOwner/Businesses")]
    public class BusinessesController : Controller
    {
        private readonly HttpClient _httpClient;

        // Absolute URL yerine sadece endpoint yolu (temiz)
        private const string EndpointPath = "api/BusinessOwners/GetBusinessByBusinessOwnerId";

        public BusinessesController(HttpClient httpClient)
        {
            _httpClient = httpClient;

            // Eğer Program.cs'de zaten ayarlayacaksan burayı kaldırabilirsin,
            // ama şimdilik garanti olsun diye burada bırakıyorum:
            _httpClient.BaseAddress = new Uri("https://localhost:7028/");
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            // Session’dan ownerId al
            var ownerId = HttpContext.Session.GetInt32("BusinessOwnerId");

            // Login yoksa login sayfasına
            if (ownerId is null || ownerId <= 0)
                return RedirectToAction("Index", "FakeAuth", new { area = "BusinessOwner" });

            // Request oluşturup header ekle (en temiz yöntem)
            using var request = new HttpRequestMessage(HttpMethod.Get, EndpointPath);
            request.Headers.Add("X-BusinessOwner-Id", ownerId.Value.ToString());

            var responseMessage = await _httpClient.SendAsync(request);

            if (!responseMessage.IsSuccessStatusCode)
            {
                // İstersen burada log at / hata mesajı göster
                return View(new List<GetBusinessesByOwnerIdDto>());
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetBusinessesByOwnerIdDto>>(jsonData);

            return View(values ?? new List<GetBusinessesByOwnerIdDto>());
        }
    }
}
