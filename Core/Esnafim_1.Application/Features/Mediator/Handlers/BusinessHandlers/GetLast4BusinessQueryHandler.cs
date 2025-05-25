using Esnafim_1.Application.Features.Mediator.Queries.BusinessQueries;
using Esnafim_1.Application.Features.Mediator.Results.BusinessResults;
using Esnafim_1.Application.Interfaces.BusinessInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.BusinessHandlers
{
    public class GetLast4BusinessQueryHandler : IRequestHandler<GetLast4BusinessQuery, List<GetLast4BusinessQueryResult>>
    {
        private readonly IBusinessRepository _businessRepository;

        public GetLast4BusinessQueryHandler(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public async Task<List<GetLast4BusinessQueryResult>> Handle(GetLast4BusinessQuery request, CancellationToken cancellationToken)
        {
            var values = _businessRepository.GetLast4BusinessList();
            return values.Select(x => new GetLast4BusinessQueryResult
            {
                BusinessId = x.BusinessId,
                BusinessName = x.BusinessName,
                City = x.City,
                District = x.District,
                ImageUrl = x.ImageUrl,
                WorkingHours = x.WorkingHours
            }).ToList();
        }
    }
}
