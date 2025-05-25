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
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand>
    {
        private readonly IRepository<Appointment> _repository;

        public UpdateAppointmentCommandHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AppointmentId);
            values.AppointmentId = request.AppointmentId;
            values.UserId = request.UserId;
            values.BusinessId = request.BusinessId;
            values.EmployeeId = request.EmployeeId;
            values.AppointmentDate = request.AppointmentDate;
            values.AppointmentTime = request.AppointmentTime;
            values.Note = request.Note;
            values.IsApproved = request.IsApproved;
            values.ApprovedDate = request.ApprovedDate;
            values.CustomerArrive = request.CustomerArrive;
            await _repository.UpdateAsync(values);
        }
    }
}
