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
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQuery, List<GetAppointmentQueryResult>>
    {
        private readonly IRepository<Appointment> _repository;

        public GetAppointmentQueryHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAppointmentQueryResult>> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAppointmentQueryResult
            {
                AppointmentId = x.AppointmentId,
                AppointmentDate = x.AppointmentDate,
                AppointmentTime = x.AppointmentTime,
                ApprovedDate = x.ApprovedDate,
                BusinessId = x.BusinessId,
                CustomerArrive = x.CustomerArrive,
                EmployeeId = x.EmployeeId,
                IsApproved = x.IsApproved,
                Note = x.Note,
                UserId = x.UserId,
            }).ToList();
        }
    }
}
