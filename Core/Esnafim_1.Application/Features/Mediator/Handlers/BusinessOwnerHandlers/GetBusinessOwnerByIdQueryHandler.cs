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
    public class GetBusinessOwnerByIdQueryHandler : IRequestHandler<GetBusinessOwnerByIdQuery, GetBusinessOwnerByIdQueryResult>
    {
        private readonly IRepository<BusinessOwner> _repository;

        public GetBusinessOwnerByIdQueryHandler(IRepository<BusinessOwner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBusinessOwnerByIdQueryResult> Handle(GetBusinessOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetBusinessOwnerByIdQueryResult
            {
                BusinessOwnerId = values.BusinessOwnerId,
                City = values.City,
                Email = values.Email,
                IsActive = values.IsActive,
                Name = values.Name,
                Password = values.Password,
                PhoneNumber = values.PhoneNumber,
                RegistrationDate = values.RegistrationDate,
            };
        }
    }
}
