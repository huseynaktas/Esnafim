using Esnafim_1.Application.Features.Mediator.Commands.AppointmentCommands;
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
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand>
    {
        private readonly IRepository<Appointment> _repository;

        public CreateAppointmentCommandHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Appointment
            {
                UserId = request.UserId,
                Note = request.Note,
                AppointmentDate = request.AppointmentDate,
                AppointmentTime = request.AppointmentTime,
                ApprovedDate = request.ApprovedDate,
                BusinessId = request.BusinessId,
                CustomerArrive = request.CustomerArrive,
                EmployeeId = request.EmployeeId,
                IsApproved = request.IsApproved
            });
        }
    }
}
