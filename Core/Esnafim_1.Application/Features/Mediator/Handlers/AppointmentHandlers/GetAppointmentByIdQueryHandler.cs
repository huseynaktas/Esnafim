using Esnafim_1.Application.Features.Mediator.Queries.AppointmentQueries;
using Esnafim_1.Application.Features.Mediator.Results.AppointmentResults;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.AppointmentHandlers
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, GetAppointmentByIdQueryResult>
    {
        private readonly IRepository<Appointment> _repository;

        public GetAppointmentByIdQueryHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task<GetAppointmentByIdQueryResult> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetAppointmentByIdQueryResult
            {
                AppointmentDate = values.ApprovedDate,
                ApprovedDate = values.ApprovedDate,
                AppointmentId = values.AppointmentId,
                AppointmentTime = values.AppointmentTime,
                BusinessId = values.BusinessId,
                CustomerArrive = values.CustomerArrive,
                EmployeeId = values.EmployeeId,
                IsApproved = values.IsApproved,
                Note = values.Note,
                UserId = values.UserId
            };
        }
    }
}
