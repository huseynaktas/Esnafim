using Esnafim_1.Application.Interfaces.EmployeeInterfaces;
using Esnafim_1.Domain.Entities;
using Esnafim_1.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Persistence.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EsnafimContext _context;

        public EmployeeRepository(EsnafimContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Employees
                .Include(x => x.BusinessEmployees)
                .AsNoTracking()
                .FirstOrDefaultAsync(e =>
                    e.Email == email &&
                    e.Password == password &&
                    e.IsActive == true);
        }

        public async Task<List<Employee>> GetEmployeesByBusinessIdAsync(int businessId)
        {
            return await _context.BusinessEmployees
                .AsNoTracking()
                .Where(be => be.BusinessId == businessId)
                .Include(be => be.Employee)                 // navigation var demiştin
                .Select(be => be.Employee)                  // Employee listesi
                .Where(e => e != null)                      // güvenlik
                .Distinct()                                 // aynı çalışan birden fazla kez bağlandıysa
                .OrderBy(e => e.Name)
                .ToListAsync();
        }
    }
}
