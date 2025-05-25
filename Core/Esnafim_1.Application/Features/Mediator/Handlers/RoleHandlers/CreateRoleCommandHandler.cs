using Esnafim_1.Application.Features.Mediator.Commands.RoleCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.RoleHandlers
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
    {
        private readonly IRepository<Role> _repository;

        public CreateRoleCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Role
            {
                Name = request.Name,
                IsActive = request.IsActive
            });
        }
    }
}
