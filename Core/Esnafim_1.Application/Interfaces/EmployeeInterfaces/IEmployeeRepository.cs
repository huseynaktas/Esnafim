using Esnafim_1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Interfaces.EmployeeInterfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesByBusinessIdAsync(int businessId);
    }
}
