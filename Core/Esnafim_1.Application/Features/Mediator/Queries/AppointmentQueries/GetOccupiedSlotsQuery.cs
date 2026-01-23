using Esnafim_1.Application.Features.Mediator.Results.AppointmentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Queries.AppointmentQueries
{
    public class GetOccupiedSlotsQuery: IRequest<GetOccupiedSlotsQueryResult>
    {
        public int BusinessId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }

        public GetOccupiedSlotsQuery(int businessId, int employeeId, DateTime date)
        {
            BusinessId = businessId;
            EmployeeId = employeeId;
            Date = date;
        }
    }
}
