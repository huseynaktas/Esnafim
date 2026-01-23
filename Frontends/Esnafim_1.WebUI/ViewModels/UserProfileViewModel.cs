using Esnafim_1.Dto.UserDtos;

namespace Esnafim_1.WebUI.ViewModels
{
    public class UserProfileViewModel
    {
        public GetUserDto User { get; set; } = null!;
        public List<UserAppointmentDto> Appointments { get; set; } = new();
    }
    public class UserAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string BusinessName { get; set; } = null!;
        public string EmployeeName { get; set; } = null!;
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Note { get; set; } = null!;
        public bool IsApproved { get; set; }
        public DateTime ApprovedDate { get; set; }
        public bool CustomerArrive { get; set; }
    }
}
