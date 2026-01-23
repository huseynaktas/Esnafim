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

        public async Task<List<TimeSpan>> GetOccupiedSlotsAsync(int businessId, int employeeId, DateTime date)
        {
            var day = date.Date;

            // .Date çevirimi bazen EF'de sorun çıkarabilir, o yüzden aralık kullanıyoruz (garanti yöntem)
            var start = day;
            var end = day.AddDays(1);

            return await _context.Appointments
                .AsNoTracking()
                .Where(a => a.BusinessId == businessId
                         && a.EmployeeId == employeeId
                         && a.AppointmentDate >= start
                         && a.AppointmentDate < end)
                .Select(a => a.AppointmentTime)
                .ToListAsync();
        }

        public async Task<bool> HasConflictAsync(int businessId, int employeeId, DateTime date, TimeSpan time)
        {
            var day = date.Date;
            var start = day;
            var end = day.AddDays(1);

            return await _context.Appointments
                .AsNoTracking()
                .AnyAsync(a => a.BusinessId == businessId
                            && a.EmployeeId == employeeId
                            && a.AppointmentDate >= start
                            && a.AppointmentDate < end
                            && a.AppointmentTime == time);
        }
    }
}
