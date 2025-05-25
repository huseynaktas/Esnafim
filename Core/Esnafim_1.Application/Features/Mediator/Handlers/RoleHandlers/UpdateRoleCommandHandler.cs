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
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly IRepository<Role> _repository;

        public UpdateRoleCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.RoleId);
            values.IsActive = request.IsActive;
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
