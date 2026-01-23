using Esnafim_1.Application.Features.Mediator.Queries.AppointmentQueries;
using Esnafim_1.Application.Features.Mediator.Results.AppointmentResults;
using Esnafim_1.Application.Interfaces.AppointmentInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.AppointmentHandlers
{
    public class GetOccupiedSlotsQueryHandler: IRequestHandler<GetOccupiedSlotsQuery, GetOccupiedSlotsQueryResult>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetOccupiedSlotsQueryHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<GetOccupiedSlotsQueryResult> Handle(GetOccupiedSlotsQuery request, CancellationToken cancellationToken)
        {
            var occupied = await _appointmentRepository.GetOccupiedSlotsAsync(request.BusinessId, request.EmployeeId, request.Date);

            return new GetOccupiedSlotsQueryResult
            {
                Slots = occupied.Select(t => t.ToString(@"hh\:mm")).ToList()
            };
        }
    }
}
