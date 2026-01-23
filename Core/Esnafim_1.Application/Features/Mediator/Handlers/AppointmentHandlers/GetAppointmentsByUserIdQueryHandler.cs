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
    public class GetAppointmentsByUserIdQueryHandler: IRequestHandler<GetAppointmentsByUserIdQuery, List<GetAppointmentsByUserIdQueryResult>>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentsByUserIdQueryHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<GetAppointmentsByUserIdQueryResult>> Handle(GetAppointmentsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _appointmentRepository.GetAppointmentsByUserIdAsync(request.UserId);

            return values.Select(x => new GetAppointmentsByUserIdQueryResult
            {
                AppointmentId = x.AppointmentId,

                BusinessId = x.BusinessId,
                BusinessName = x.Business.BusinessName,       // Business entity property adın farklıysa değiştir
                EmployeeId = x.EmployeeId,
                EmployeeName = x.Employee.Name,       // Employee entity property adın farklıysa değiştir

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
