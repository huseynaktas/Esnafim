using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.BusinessOwnerDtos
{
    public class GetBusinessesByOwnerIdDto
    {
        public int BusinessId { get; set; }
        public string? BusinessName { get; set; }
        public bool IsActive { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
    }
}
