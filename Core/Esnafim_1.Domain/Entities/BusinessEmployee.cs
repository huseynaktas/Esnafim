using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Domain.Entities
{
    public class BusinessEmployee
    {
        public int BusinessEmployeeId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
    }
}
