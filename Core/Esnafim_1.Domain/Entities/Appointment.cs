using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Domain.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Note { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ApprovedDate { get; set; }
        public bool CustomerArrive { get; set; }
    }
}
