using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.AppointmentsDtos
{
    public class GetAppointmentByEmployeeIdDto
    {
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
        public int BusinessId { get; set; }
        public int EmployeeId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; } = "00:00:00";

        public string? Note { get; set; }

        public bool IsApproved { get; set; }
        public DateTime ApprovedDate { get; set; }

        public bool CustomerArrive { get; set; }

        public string? UserName { get; set; }
        public string? UserMail { get; set; }
        public string? UserPhone { get; set; }
    }
}
