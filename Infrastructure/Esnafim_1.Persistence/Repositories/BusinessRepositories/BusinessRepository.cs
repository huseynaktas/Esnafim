using Esnafim_1.Application.Interfaces.BusinessInterfaces;
using Esnafim_1.Domain.Entities;
using Esnafim_1.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Persistence.Repositories.BusinessRepositories
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly EsnafimContext _context;

        public BusinessRepository(EsnafimContext context)
        {
            _context = context;
        }

        public List<Business> GetLast4BusinessList()
        {
            var values = _context.Businesses.OrderByDescending(x => x.BusinessId).Take(4).ToList();
            return values;
        }
    }
}
