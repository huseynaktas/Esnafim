using System.ComponentModel.DataAnnotations;

namespace Esnafim_1.WebUI.ViewModels
{
    public class UserLoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
