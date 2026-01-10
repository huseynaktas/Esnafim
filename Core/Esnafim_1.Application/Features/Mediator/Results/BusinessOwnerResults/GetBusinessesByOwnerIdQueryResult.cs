using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Results.BusinessOwnerResults
{
    public class GetBusinessesByOwnerIdQueryResult
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
