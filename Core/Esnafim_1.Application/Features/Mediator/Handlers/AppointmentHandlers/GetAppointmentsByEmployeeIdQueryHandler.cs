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
    public class GetAppointmentsByEmployeeIdQueryHandler : IRequestHandler<GetAppointmentsByEmployeeIdQuery, List<GetAppointmentsByEmployeeIdQueryResult>>
    {
        private readonly IAppointmentRepository _repository;

        public GetAppointmentsByEmployeeIdQueryHandler(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAppointmentsByEmployeeIdQueryResult>> Handle(GetAppointmentsByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _repository.GetAppointmentsByEmployeeId(request.EmployeeId);
            return appointment.Select(x =>  new GetAppointmentsByEmployeeIdQueryResult
            {
                AppointmentId = x.AppointmentId,
                EmployeeId = x.EmployeeId,
                UserId = x.UserId,
                BusinessId = x.BusinessId,
                AppointmentDate = x.AppointmentDate,
                AppointmentTime = x.AppointmentTime,
                Note = x.Note,
                IsApproved = x.IsApproved,
                ApprovedDate = x.ApprovedDate,
                CustomerArrive = x.CustomerArrive,
                UserName = x.User.Name,
                UserMail = x.User.Email,
                UserPhone = x.User.Phone
            }).ToList();
        }
    }
}
