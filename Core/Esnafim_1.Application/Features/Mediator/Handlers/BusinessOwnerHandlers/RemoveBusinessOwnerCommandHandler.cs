using Esnafim_1.Application.Features.Mediator.Commands.BusinessOwnerCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.BusinessOwnerHandlers
{
    public class RemoveBusinessOwnerCommandHandler : IRequestHandler<RemoveBusinessOwnerCommand>
    {
        private readonly IRepository<BusinessOwner> _repository;

        public RemoveBusinessOwnerCommandHandler(IRepository<BusinessOwner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBusinessOwnerCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
