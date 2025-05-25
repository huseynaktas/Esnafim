using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.SocialMediaDtos
{
    public class UpdateSocialMediaDto
    {
        public int socialMediaId { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string icon { get; set; }
    }
}
