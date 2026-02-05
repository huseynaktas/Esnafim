using System.ComponentModel.DataAnnotations;

namespace Esnafim_1.WebUI.Areas.BusinessEmployee.ViewModels
{
    public class ApproveAppointmentViewModel
    {
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
        public int BusinessId { get; set; }
        public int EmployeeId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; } = "00:00:00";
        public string? Note { get; set; }
        public bool CustomerArrive { get; set; }

    }
}
