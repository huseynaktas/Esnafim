using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.UserDtos
{
    public class ResultUserDto
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string neighborhood { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; }
        public DateTime registrationDate { get; set; }
    }
}
