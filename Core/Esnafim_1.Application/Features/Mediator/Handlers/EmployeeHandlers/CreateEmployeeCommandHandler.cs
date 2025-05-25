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
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand>
    {
        private readonly IRepository<Employee> _repository;

        public CreateEmployeeCommandHandler(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Employee
            {
                Email = request.Email,
                ImageUrl = request.ImageUrl,
                IsActive = request.IsActive,
                Name = request.Name,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                RegistrationDate = request.RegistrationDate
            });
        }
    }
}
