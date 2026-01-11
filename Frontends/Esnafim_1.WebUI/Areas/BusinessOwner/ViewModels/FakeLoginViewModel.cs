using System.ComponentModel.DataAnnotations;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.ViewModels
{
    public class FakeLoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public string? ErrorMessage { get; set; }
    }
}
