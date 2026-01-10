using Esnafim_1.Application.Interfaces.BusinessOwnerInterfaces;
using Esnafim_1.Domain.Entities;
using Esnafim_1.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Persistence.Repositories.BusinessOwnerRepositories
{
    public class BusinessOwnerRepository : IBusinessOwnerRepository
    {
        private readonly EsnafimContext _context;

        public BusinessOwnerRepository(EsnafimContext context)
        {
            _context = context;
        }
        public async Task<List<Business>> GetBusinessesByOwnerIdAsync(int businessOwnerId)
        {
            return await _context.BusinessOwnerships
                .Where(x => x.BusinessOwnerId == businessOwnerId)
                .Select(x => x.Business)          
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
