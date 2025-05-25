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
    public class UpdateBusinessCategoryCommandHandler : IRequestHandler<UpdateBusinessCategoryCommand>
    {
        private readonly IRepository<BusinessCategory> _repository;

        public UpdateBusinessCategoryCommandHandler(IRepository<BusinessCategory> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBusinessCategoryCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BusinessCategoryId);
            values.IsActive = request.IsActive;
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
