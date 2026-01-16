using Esnafim_1.Dto.AppointmentsDtos;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.ViewModels.BusinessOwnerAppointmentVM
{
    public class BusinessAppointmentIndexViewModel
    {
        public List<GetAppointmentListDto> Past { get; set; } = new();
        public List<GetAppointmentListDto> Pending { get; set; } = new();
        public List<GetAppointmentListDto> Approved { get; set; } = new();
    }
}
