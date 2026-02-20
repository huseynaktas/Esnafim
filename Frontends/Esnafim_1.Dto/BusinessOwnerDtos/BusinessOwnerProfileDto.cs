using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.BusinessOwnerDtos
{
    public class BusinessOwnerProfileDto
    {
        public int BusinessOwnerId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } // API dönüyor ama UI'da göstermeyebiliriz
        public bool IsActive { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
