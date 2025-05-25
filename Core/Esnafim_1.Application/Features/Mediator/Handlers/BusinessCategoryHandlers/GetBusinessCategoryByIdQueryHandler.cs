using Esnafim_1.Application.Features.Mediator.Queries.BusinessCategoryQueries;
using Esnafim_1.Application.Features.Mediator.Results.BusinessCategoryResults;
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
    public class GetBusinessCategoryByIdQueryHandler : IRequestHandler<GetBusinessCategoryByIdQuery, GetBusinessCategoryByIdQueryResult>
    {
        private readonly IRepository<BusinessCategory> _repository;

        public GetBusinessCategoryByIdQueryHandler(IRepository<BusinessCategory> repository)
        {
            _repository = repository;
        }

        public async Task<GetBusinessCategoryByIdQueryResult> Handle(GetBusinessCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetBusinessCategoryByIdQueryResult
            {
                BusinessCategoryId = values.BusinessCategoryId,
                IsActive = values.IsActive,
                Name = values.Name
            };
        }
    }
}
