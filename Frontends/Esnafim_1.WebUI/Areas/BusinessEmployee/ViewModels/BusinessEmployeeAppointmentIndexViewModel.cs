using Esnafim_1.Dto.AppointmentsDtos;

namespace Esnafim_1.WebUI.Areas.BusinessEmployee.ViewModels
{
    public class BusinessEmployeeAppointmentIndexViewModel
    {
        public List<GetAppointmentByEmployeeIdDto> Approved { get; set; } = new();
        public List<GetAppointmentByEmployeeIdDto> Pending { get; set; } = new();
        public List<GetAppointmentByEmployeeIdDto> Past { get; set; } = new();

        public int ApprovedCount => Approved.Count;
        public int PendingCount => Pending.Count;
        public int PastCount => Past.Count;
    }
}
