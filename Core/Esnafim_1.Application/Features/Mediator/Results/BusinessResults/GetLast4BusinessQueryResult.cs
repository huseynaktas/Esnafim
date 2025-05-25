using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Results.BusinessResults
{
    public class GetLast4BusinessQueryResult
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string ImageUrl { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string WorkingHours { get; set; }
    }
}
