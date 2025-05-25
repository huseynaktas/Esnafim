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
    public class CreateBusinessCategoryCommandHandler : IRequestHandler<CreateBusinessCategoryCommand>
    {
        private readonly IRepository<BusinessCategory> _repository;

        public CreateBusinessCategoryCommandHandler(IRepository<BusinessCategory> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBusinessCategoryCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new BusinessCategory
            {
                Name = request.Name,
                IsActive = request.IsActive,
            });
        }
    }
}
