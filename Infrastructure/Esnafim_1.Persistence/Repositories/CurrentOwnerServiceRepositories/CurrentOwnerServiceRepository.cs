using Esnafim_1.Application.Interfaces.CurrentOwnerInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Persistence.Repositories.CurrentOwnerServiceRepositories
{
    public class CurrentOwnerServiceRepository : ICurrentOwnerService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentOwnerServiceRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int BusinessOwnerId
        {
            get
            {
                var value = _httpContextAccessor.HttpContext?.Request.Headers["X-BusinessOwner-Id"].ToString();
                return int.TryParse(value, out var id) ? id : 0;
            }
        }
    }
}
