using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.BusinessDtos
{
    public class GetLast4BusinessDto
    {
        public int businessId { get; set; }
        public string businessName { get; set; }
        public string imageUrl { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string workingHours { get; set; }
    }
}
