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
    public class GetAppointmentsByBusinessIdQueryHandler : IRequestHandler<GetAppointmentsByBusinessIdQuery, List<GetAppointmentsByBusinessIdQueryResult>>
    {
        private readonly IAppointmentRepository _repository;

        public GetAppointmentsByBusinessIdQueryHandler(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAppointmentsByBusinessIdQueryResult>> Handle(GetAppointmentsByBusinessIdQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _repository.GetAppointmentsByBusinessIdAsync(request.Id);
            return appointment.Select(x => new GetAppointmentsByBusinessIdQueryResult
            {
                AppointmentId = x.AppointmentId,
                UserId = x.UserId,
                BusinessId = x.BusinessId,
                EmployeeId = x.EmployeeId,
                AppointmentDate = x.AppointmentDate,
                AppointmentTime = x.AppointmentTime,
                Note = x.Note,
                IsApproved = x.IsApproved,
                ApprovedDate = x.ApprovedDate,
                CustomerArrive = x.CustomerArrive
            }).ToList();
        }
    }
}
