using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.BusinessEmployeesDtos
{
    public class BusinessEmployeeLoginResponseDto
    {
        public int EmployeeId { get; set; }
        public int BusinessId { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
