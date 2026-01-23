using System.ComponentModel.DataAnnotations;

namespace Esnafim_1.WebUI.ViewModels
{
    public class CreateAppointmentViewModel
    {
        [Required]
        public int BusinessId { get; set; }

        [Required(ErrorMessage = "Çalışan seçmelisin.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Tarih seçmelisin.")]
        public DateTime AppointmentDate { get; set; }

        // Dropdown value: "10:00", "10:30" ...
        [Required(ErrorMessage = "Saat seçmelisin.")]
        public string AppointmentTime { get; set; } = null!;

        [Required(ErrorMessage = "Not alanı zorunlu.")]
        public string Note { get; set; } = null!;
    }
}
