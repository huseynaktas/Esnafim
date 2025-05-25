using Esnafim_1.Application.Features.Mediator.Queries.BusinessQueries;
using Esnafim_1.Application.Features.Mediator.Results.BusinessResults;
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
    public class GetBusinessQueryHandler : IRequestHandler<GetBusinessQuery, List<GetBusinessQueryResult>>
    {
        private readonly IRepository<Business> _repository;

        public GetBusinessQueryHandler(IRepository<Business> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBusinessQueryResult>> Handle(GetBusinessQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBusinessQueryResult
            {
                BusinessId = x.BusinessId,
                Address = x.Address,
                BusinessName = x.BusinessName,
                BusinessPhone = x.BusinessPhone,
                City = x.City,
                District = x.District,
                Email = x.Email,
                EnterpriseNumber = x.EnterpriseNumber,
                ImageUrl = x.ImageUrl,
                IsActive = x.IsActive,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Neighborhood = x.Neighborhood,
                RegistrationDate = x.RegistrationDate,
                WorkingHours = x.WorkingHours
            }).ToList();
        }
    }
}
