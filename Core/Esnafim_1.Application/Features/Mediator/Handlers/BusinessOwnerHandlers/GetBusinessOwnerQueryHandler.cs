using Esnafim_1.Application.Features.Mediator.Queries.BusinessOwnerQueries;
using Esnafim_1.Application.Features.Mediator.Results.BusinessOwnerResults;
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
    public class GetBusinessOwnerQueryHandler : IRequestHandler<GetBusinessOwnerQuery, List<GetBusinessOwnerQueryResult>>
    {
        private readonly IRepository<BusinessOwner> _repository;

        public GetBusinessOwnerQueryHandler(IRepository<BusinessOwner> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBusinessOwnerQueryResult>> Handle(GetBusinessOwnerQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBusinessOwnerQueryResult
            {
                BusinessOwnerId = x.BusinessOwnerId,
                City = x.City,
                Email = x.Email,
                IsActive = x.IsActive,
                Name = x.Name,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber,
                RegistrationDate = x.RegistrationDate
            }).ToList();
        }
    }
}
