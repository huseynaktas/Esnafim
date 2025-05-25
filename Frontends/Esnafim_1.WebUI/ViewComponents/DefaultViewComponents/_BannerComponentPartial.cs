using Esnafim_1.Dto.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Esnafim_1.WebUI.ViewComponents.DefaultViewComponents
{
    public class _BannerComponentPartial: ViewComponent
    {
        private readonly HttpClient _client;
        public string apiConnectedUrl = "https://localhost:7028/api/Banners";

        public _BannerComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMesage = await _client.GetAsync(apiConnectedUrl);
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
