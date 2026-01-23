using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Results.AppointmentResults
{
    public class GetOccupiedSlotsQueryResult
    {
        public List<string> Slots { get; set; } = new();
    }
}
