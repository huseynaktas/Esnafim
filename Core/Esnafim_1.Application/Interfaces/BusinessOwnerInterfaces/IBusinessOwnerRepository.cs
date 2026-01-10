using Esnafim_1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Interfaces.BusinessOwnerInterfaces
{
    public interface IBusinessOwnerRepository
    {
        Task<List<Business>> GetBusinessesByOwnerIdAsync(int businessOwnerId);
    }
}
