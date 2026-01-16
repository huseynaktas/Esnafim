using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.AppointmentsDtos
{
    public class GetAppointmentListDto
    {
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
        public int BusinessId { get; set; }
        public int? EmployeeId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }

        public string? Note { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool? CustomerArrive { get; set; }

        // UI ve filtreleme için hayat kurtarır (past/pending/approved)
        public DateTime StartDate => AppointmentDate.Date + AppointmentTime;
    }
}
