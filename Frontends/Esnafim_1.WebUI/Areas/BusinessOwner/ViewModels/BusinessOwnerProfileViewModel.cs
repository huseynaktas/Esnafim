namespace Esnafim_1.WebUI.Areas.BusinessOwner.ViewModels
{
    public class BusinessOwnerProfileViewModel
    {
        public int BusinessOwnerId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
