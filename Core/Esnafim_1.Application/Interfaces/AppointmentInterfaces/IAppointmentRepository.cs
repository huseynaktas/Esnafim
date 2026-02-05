using Esnafim_1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Interfaces.AppointmentInterfaces
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAppointmentsByBusinessIdAsync(int businessId);

        Task<List<TimeSpan>> GetOccupiedSlotsAsync(int businessId, int employeeId, DateTime date);
        Task<bool> HasConflictAsync(int businessId, int employeeId, DateTime date, TimeSpan time);

        Task<List<Appointment>> GetAppointmentsByUserIdAsync(int userId);

        Task<List<Appointment>> GetAppointmentsByEmployeeId(int employeeId);

    }
}
