using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Domain.Entities
{
    public class BusinessOwnership
    {
        public int BusinessOwnershipId { get; set; }
        public int BusinessOwnerId { get; set; }
        public BusinessOwner BusinessOwner { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
    }
}
