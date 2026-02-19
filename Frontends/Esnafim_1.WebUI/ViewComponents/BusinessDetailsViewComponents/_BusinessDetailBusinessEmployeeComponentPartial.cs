using Esnafim_1.Dto.EmployeeDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Esnafim_1.WebUI.ViewComponents.BusinessDetailsViewComponents
{
    public class _BusinessDetailBusinessEmployeeComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BusinessDetailBusinessEmployeeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int businessId)
        {
            var client = _httpClientFactory.CreateClient();

            var apiLink = $"https://localhost:7028/api/Employees/GetEmployeesByBusinessId/{businessId}";
            var responseMessage = await client.GetAsync(apiLink);

            if (!responseMessage.IsSuccessStatusCode)
            {
                // View boş liste ile dönsün, UI patlamasın
                return View(new List<GetEmployeeByBusinessIdDto>());
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            // API bazen null dönebilir; garantiye al
            var values = JsonConvert.DeserializeObject<List<GetEmployeeByBusinessIdDto>>(jsonData)
                         ?? new List<GetEmployeeByBusinessIdDto>();

            return View(values);
        }
    }
}
