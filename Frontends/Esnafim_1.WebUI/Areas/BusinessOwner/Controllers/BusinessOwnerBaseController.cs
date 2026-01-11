using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.Controllers
{
    [Area("BusinessOwner")]
    public abstract class BusinessOwnerBaseController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        protected BusinessOwnerBaseController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected HttpClient CreateApiClientWithOwnerHeader()
        {
            var client = _httpClientFactory.CreateClient("EsnafimApi");

            var ownerId = HttpContext.Session.GetInt32("BusinessOwnerId");

            if (ownerId is not null && ownerId > 0)
            {
                // Aynı header iki kere eklenmesin diye önce kaldır
                if (client.DefaultRequestHeaders.Contains("X-BusinessOwner-Id"))
                    client.DefaultRequestHeaders.Remove("X-BusinessOwner-Id");

                client.DefaultRequestHeaders.Add("X-BusinessOwner-Id", ownerId.Value.ToString());
            }

            return client;
        }

        protected int GetOwnerIdOrZero()
            => HttpContext.Session.GetInt32("BusinessOwnerId") ?? 0;
    }
}
