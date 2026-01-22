using System.ComponentModel.DataAnnotations;

namespace Esnafim_1.WebUI.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Phone { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string District { get; set; } = null!;

        [Required]
        public string Neighborhood { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required, MinLength(6)]
        public string Password { get; set; } = null!;
    }
}
