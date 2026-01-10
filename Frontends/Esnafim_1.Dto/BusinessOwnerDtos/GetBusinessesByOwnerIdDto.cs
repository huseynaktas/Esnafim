using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.BusinessOwnerDtos
{
    public class GetBusinessesByOwnerIdDto
    {
        public string? BusinessName { get; set; }
        public bool IsActive { get; set; }
    }
}
