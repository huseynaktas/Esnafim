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
    public class GetBusinessByIdQueryHandler : IRequestHandler<GetBusinessByIdQuery, GetBusinessByIdQueryResult>
    {
        private readonly IRepository<Business> _repository;

        public GetBusinessByIdQueryHandler(IRepository<Business> repository)
        {
            _repository = repository;
        }

        public async Task<GetBusinessByIdQueryResult> Handle(GetBusinessByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetBusinessByIdQueryResult
            {
                Address = values.Address,
                BusinessId = values.BusinessId,
                BusinessName = values.BusinessName,
                BusinessPhone = values.BusinessPhone,
                City = values.City,
                District = values.District,
                Email = values.Email,
                EnterpriseNumber = values.EnterpriseNumber,
                ImageUrl = values.ImageUrl,
                IsActive = values.IsActive,
                Latitude = values.Latitude,
                Longitude = values.Longitude,
                Neighborhood = values.Neighborhood,
                RegistrationDate = values.RegistrationDate,
                WorkingHours = values.WorkingHours
            };
        }
    }
}
