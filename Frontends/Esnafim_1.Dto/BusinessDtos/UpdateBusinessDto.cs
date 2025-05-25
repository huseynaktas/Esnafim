using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.BusinessDtos
{
    public class UpdateBusinessDto
    {
        public int businessId { get; set; }
        public string businessName { get; set; }
        public string imageUrl { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string neighborhood { get; set; }
        public string address { get; set; }
        public int latitude { get; set; }
        public int longitude { get; set; }
        public string businessPhone { get; set; }
        public string email { get; set; }
        public bool isActive { get; set; }
        public DateTime registrationDate { get; set; }
        public string workingHours { get; set; }
        public string enterpriseNumber { get; set; }


    }
}
