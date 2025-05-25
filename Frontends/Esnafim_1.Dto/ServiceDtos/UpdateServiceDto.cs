using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.ServiceDtos
{
    public class UpdateServiceDto
    {
        public int serviceId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
    }
}
