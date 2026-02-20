using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Esnafim_1.Dto.BusinessOwnerDtos;
using Esnafim_1.WebUI.Areas.BusinessOwner.ViewModels;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.Controllers
{
    [Area("BusinessOwner")]
    [Route("BusinessOwner/BusinessOwnerProfile")]
    public class BusinessOwnerProfileController : BusinessOwnerBaseController
    {
        public BusinessOwnerProfileController(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var ownerId = GetOwnerIdOrZero();
            if (ownerId <= 0)
                return RedirectToAction("Index", "FakeAuth", new { area = "BusinessOwner" });

            var client = CreateApiClientWithOwnerHeader();

            var owner = await client.GetFromJsonAsync<BusinessOwnerProfileDto>($"api/BusinessOwners/{ownerId}");

            if (owner is null || owner.BusinessOwnerId <= 0)
            {
                // İstersen burada güzel bir hata ekranı/alert basarsın
                return View(new BusinessOwnerProfileViewModel());
            }

            var vm = new BusinessOwnerProfileViewModel
            {
                BusinessOwnerId = owner.BusinessOwnerId,
                Name = owner.Name,
                Email = owner.Email,
                PhoneNumber = owner.PhoneNumber,
                City = owner.City,
                IsActive = owner.IsActive,
                RegistrationDate = owner.RegistrationDate
            };

            // Bonus: API’den gelen "name" ile session’daki adı senkronla
            if (!string.IsNullOrWhiteSpace(owner.Name))
                HttpContext.Session.SetString("BusinessOwnerName", owner.Name);

            return View(vm);
        }

        // Şimdilik update endpoint'in yok; hazır dursun diye iskelet bırakıyorum.
        // Endpoint ekleyince bunu aktive ederiz.
        /*
        [HttpPost("Index")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(BusinessOwnerProfileViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = CreateApiClientWithOwnerHeader();

            var resp = await client.PutAsJsonAsync($"api/BusinessOwners/{model.BusinessOwnerId}", new
            {
                businessOwnerId = model.BusinessOwnerId,
                name = model.Name,
                email = model.Email,
                phoneNumber = model.PhoneNumber,
                city = model.City,
                isActive = model.IsActive
            });

            if (!resp.IsSuccessStatusCode)
            {
                ViewBag.Error = "Güncelleme sırasında hata oluştu.";
                return View(model);
            }

            HttpContext.Session.SetString("BusinessOwnerName", model.Name ?? "");
            ViewBag.Success = "Profil güncellendi.";
            return View(model);
        }
        */
    }
}