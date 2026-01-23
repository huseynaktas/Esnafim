using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Results.AppointmentResults
{
    public class GetAppointmentsByUserIdQueryResult
    {
        public int AppointmentId { get; set; }

        public int BusinessId { get; set; }
        public string BusinessName { get; set; } = null!;

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;

        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }

        public string Note { get; set; } = null!;
        public bool IsApproved { get; set; }
        public DateTime ApprovedDate { get; set; }
        public bool CustomerArrive { get; set; }
    }
}
