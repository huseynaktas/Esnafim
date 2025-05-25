using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Results.BusinessCategoryResults
{
    public class GetBusinessCategoryQueryResult
    {
        public int BusinessCategoryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
