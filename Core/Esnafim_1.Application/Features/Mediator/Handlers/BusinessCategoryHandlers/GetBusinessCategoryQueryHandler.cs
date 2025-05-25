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
    public class GetBusinessCategoryQueryHandler : IRequestHandler<GetBusinessCategoryQuery, List<GetBusinessCategoryQueryResult>>
    {
        private readonly IRepository<BusinessCategory> _repository;

        public GetBusinessCategoryQueryHandler(IRepository<BusinessCategory> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBusinessCategoryQueryResult>> Handle(GetBusinessCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBusinessCategoryQueryResult
            {
                BusinessCategoryId = x.BusinessCategoryId,
                IsActive = x.IsActive,
                Name = x.Name,
            }).ToList();
        }
    }
}
