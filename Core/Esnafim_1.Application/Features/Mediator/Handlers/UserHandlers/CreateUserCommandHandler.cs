using Esnafim_1.Application.Features.Mediator.Commands.UserCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.UserHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IRepository<User> _repository;

        public CreateUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new User
            {
                Address = request.Address,
                City = request.City,
                District = request.District,
                Email = request.Email,
                IsActive = request.IsActive,
                Name = request.Name,
                Neighborhood = request.Neighborhood,
                Password = request.Password,
                Phone = request.Phone,
                RegistrationDate = request.RegistrationDate,
            });
        }
    }
}
