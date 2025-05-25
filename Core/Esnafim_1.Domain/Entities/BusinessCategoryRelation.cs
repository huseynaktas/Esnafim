using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Domain.Entities
{
    public class BusinessCategoryRelation
    {
        public int BusinessCategoryRelationId { get; set; }
        public int BusinessCategoryId { get; set; }
        public BusinessCategory BusinessCategory { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
    }
}
