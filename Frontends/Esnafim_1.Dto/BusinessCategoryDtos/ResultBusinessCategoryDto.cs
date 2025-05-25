using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.BusinessCategoryDtos
{
    public class ResultBusinessCategoryDto
    {
        public int businessCategoryId { get; set; }
        public string name { get; set; }
        public bool isActive { get; set; }
    }
}
