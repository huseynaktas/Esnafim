using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Results.UserResults
{
    public class GetUserByEmailQueryResult
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;

        // Hash'li şifre (login doğrulaması için lazım)
        public string Password { get; set; } = null!;

        public bool IsActive { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
