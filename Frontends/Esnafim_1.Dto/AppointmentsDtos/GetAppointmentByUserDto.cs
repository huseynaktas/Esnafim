using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.AppointmentsDtos
{
    public class GetAppointmentByUserDto
    {
        public int AppointmentId { get; set; }
        public string BusinessName { get; set; } = null!;
        public string EmployeeName { get; set; } = null!;
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; } = null!; // ister string, ister TimeSpan
        public string Note { get; set; } = null!;
        public bool IsApproved { get; set; }
        public DateTime ApprovedDate { get; set; }
        public bool CustomerArrive { get; set; }
    }
}
