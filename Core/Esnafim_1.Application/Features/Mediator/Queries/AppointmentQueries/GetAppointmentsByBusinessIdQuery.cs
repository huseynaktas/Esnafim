using Esnafim_1.Application.Features.Mediator.Results.AppointmentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Queries.AppointmentQueries
{
    public class GetAppointmentsByBusinessIdQuery: IRequest<List<GetAppointmentsByBusinessIdQueryResult>>
    {
        public int Id { get; set; }

        public GetAppointmentsByBusinessIdQuery(int id)
        {
            Id = id;
        }
    }
}
