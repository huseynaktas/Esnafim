using Esnafim_1.Application.Features.Mediator.Commands.BusinessCommentCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.BusinessCommentHandlers
{
    public class RemoveBusinessCommentCommandHandler : IRequestHandler<RemoveBusinessCommentCommand>
    {
        private readonly IRepository<BusinessComment> _repository;

        public RemoveBusinessCommentCommandHandler(IRepository<BusinessComment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBusinessCommentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
