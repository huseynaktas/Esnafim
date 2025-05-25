using Esnafim_1.Application.Features.Mediator.Commands.BusinessCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.BusinessHandlers
{
    public class RemoveBusinessCommandHandler : IRequestHandler<RemoveBusinessCommand>
    {
        private readonly IRepository<Business> _repository;

        public RemoveBusinessCommandHandler(IRepository<Business> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBusinessCommand request, CancellationToken cancellationToken)
        {
            
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
