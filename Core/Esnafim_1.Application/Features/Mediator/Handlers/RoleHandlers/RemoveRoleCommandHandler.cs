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
    public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommand>
    {
        private readonly IRepository<Role> _repository;

        public RemoveRoleCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
