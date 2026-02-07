using System.ComponentModel.DataAnnotations;

namespace Esnafim_1.WebUI.Areas.BusinessEmployee.ViewModels
{
    public class BusinessEmployeeProfileViewModel
    {
        public int EmployeeId { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Yeni fotoğraf linki zorunludur.")]
        [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
        public string NewImageUrl { get; set; } = string.Empty;
    }
}
