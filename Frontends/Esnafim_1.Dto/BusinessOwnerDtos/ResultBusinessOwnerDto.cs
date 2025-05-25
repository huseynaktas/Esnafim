using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.BusinessOwnerDtos
{
    public class ResultBusinessOwnerDto
    {
        public int businessOwnerId { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; }
        public DateTime registrationDate { get; set; }
    }
}
