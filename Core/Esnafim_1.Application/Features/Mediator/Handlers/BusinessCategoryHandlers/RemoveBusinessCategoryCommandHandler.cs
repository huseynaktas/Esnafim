using Esnafim_1.Application.Features.Mediator.Commands.BusinessCategoryCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.BusinessCategoryHandlers
{
    public class RemoveBusinessCategoryCommandHandler : IRequestHandler<RemoveBusinessCategoryCommand>
    {
        private readonly IRepository<BusinessCategory> _repository;

        public RemoveBusinessCategoryCommandHandler(IRepository<BusinessCategory> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBusinessCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
