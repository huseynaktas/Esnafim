using Esnafim_1.Dto.BusinessDtos;
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

        // ✅ EDIT GET
        [HttpGet("Edit/{businessId:int}")]
        public async Task<IActionResult> Edit(int businessId)
        {
            var ownerId = HttpContext.Session.GetInt32("BusinessOwnerId");
            if (ownerId is null || ownerId <= 0)
                return RedirectToAction("Index", "FakeAuth", new { area = "BusinessOwner" });

            // GET: /api/Businesses/{id}
            var business = await _httpClient.GetFromJsonAsync<UpdateBusinessDto>($"api/Businesses/{businessId}");

            if (business == null)
                return RedirectToAction("Index");

            return View("Edit", business);
        }

        // ✅ EDIT POST -> PUT /api/Businesses  (ID body'den gidiyor)
        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateBusinessDto model)
        {
            // Güvenlik: businessId gelmiş mi?
            if (model == null || model.businessId <= 0)
            {
                ModelState.AddModelError("", "Geçersiz işletme bilgisi (businessId gelmedi).");
                return View("Edit", model);
            }

            if (!ModelState.IsValid)
                return View("Edit", model);

            var response = await _httpClient.PutAsJsonAsync("api/Businesses", model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "İşletme güncellenemedi. Lütfen tekrar deneyin.");
                return View("Edit", model);
            }

            return RedirectToAction("Index");
        }


    }
}
