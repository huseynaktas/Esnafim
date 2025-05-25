using Esnafim_1.Application.Features.Mediator.Queries.UserQueries;
using Esnafim_1.Application.Features.Mediator.Results.UserResults;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.UserHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IRepository<User> _repository;

        public GetUserByIdQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetUserByIdQueryResult
            {
                Address = values.Address,
                City = values.City,
                District = values.District,
                Email = values.Email,
                IsActive = values.IsActive,
                Name = values.Name,
                Neighborhood = values.Neighborhood,
                Password = values.Password,
                Phone = values.Phone,
                RegistrationDate = values.RegistrationDate,
                UserId = values.UserId
            };
        }
    }
}
