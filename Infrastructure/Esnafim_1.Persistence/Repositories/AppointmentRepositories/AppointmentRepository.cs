using Esnafim_1.Application.Interfaces.AppointmentInterfaces;
using Esnafim_1.Domain.Entities;
using Esnafim_1.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Persistence.Repositories.AppointmentRepositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly EsnafimContext _context;

        public AppointmentRepository(EsnafimContext context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAppointmentsByBusinessIdAsync(int businessId)
        {
            return await _context.Appointments
                .AsNoTracking()
                .Where(x => x.BusinessId == businessId)
                .Include(x => x.User)
                .Include(x => x.Employee)
                .Include(x => x.Business)
                .OrderByDescending(x => x.AppointmentDate)
                .ToListAsync();
        }
    }
}
