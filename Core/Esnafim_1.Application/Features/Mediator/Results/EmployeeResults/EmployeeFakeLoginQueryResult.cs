using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Results.EmployeeResults
{
    public class EmployeeFakeLoginQueryResult
    {
        public int EmployeeId { get; set; }
        public int BusinessId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
