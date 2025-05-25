using Esnafim_1.Application.Features.Mediator.Results.AppointmentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Queries.AppointmentQueries
{
    public class GetAppointmentByIdQuery: IRequest<GetAppointmentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetAppointmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
