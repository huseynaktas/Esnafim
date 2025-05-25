using Esnafim_1.Application.Features.Mediator.Commands.EmployeeCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.EmployeeHandlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IRepository<Employee> _repository;

        public UpdateEmployeeCommandHandler(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.EmployeeId);
            values.Email = request.Email;
            values.IsActive = request.IsActive;
            values.ImageUrl = request.ImageUrl;
            values.Name = request.Name;
            values.Password = request.Password;
            values.PhoneNumber = request.PhoneNumber;
            values.RegistrationDate = request.RegistrationDate;
            await _repository.UpdateAsync(values);
        }
    }
}
