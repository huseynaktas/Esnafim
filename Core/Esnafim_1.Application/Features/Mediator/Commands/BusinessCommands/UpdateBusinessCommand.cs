using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Commands.BusinessCommands
{
    public class UpdateBusinessCommand: IRequest
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string ImageUrl { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }  // Enlem
        public double Longitude { get; set; } // Boylam
        public string BusinessPhone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string WorkingHours { get; set; }
        public string EnterpriseNumber { get; set; }
    }
}
