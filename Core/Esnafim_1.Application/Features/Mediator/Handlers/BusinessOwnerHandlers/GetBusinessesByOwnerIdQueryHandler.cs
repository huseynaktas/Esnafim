using Esnafim_1.Application.Features.Mediator.Queries.BusinessOwnerQueries;
using Esnafim_1.Application.Features.Mediator.Results.BusinessOwnerResults;
using Esnafim_1.Application.Interfaces.BusinessOwnerInterfaces;
using Esnafim_1.Application.Interfaces.CurrentOwnerInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.BusinessOwnerHandlers
{
    public class GetBusinessesByOwnerIdQueryHandler : IRequestHandler<GetBusinessesByOwnerIdQuery, List<GetBusinessesByOwnerIdQueryResult>>
    {
        private readonly IBusinessOwnerRepository _repository;
        private readonly ICurrentOwnerService _currentOwner;

        public GetBusinessesByOwnerIdQueryHandler(IBusinessOwnerRepository repository, ICurrentOwnerService currentOwner)
        {
            _repository = repository;
            _currentOwner = currentOwner;
        }

        public async Task<List<GetBusinessesByOwnerIdQueryResult>> Handle(GetBusinessesByOwnerIdQuery request, CancellationToken cancellationToken)
        {
            var ownerId = _currentOwner.BusinessOwnerId;
            var values = await _repository.GetBusinessesByOwnerIdAsync(ownerId);
            return values.Select(x => new GetBusinessesByOwnerIdQueryResult
            {
                BusinessId = x.BusinessId,
                BusinessName = x.BusinessName,
                City = x.City,
                District = x.District,
                IsActive = x.IsActive,
            }).ToList();
        }
    }
}
