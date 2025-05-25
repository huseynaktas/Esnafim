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
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUserQueryResult>>
    {
        private readonly IRepository<User> _repository;

        public GetUserQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetUserQueryResult>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetUserQueryResult
            {
                Address = x.Address,
                City = x.City,
                District = x.District,
                Email = x.Email,
                IsActive = x.IsActive,
                Name = x.Name,
                Neighborhood = x.Neighborhood,
                Password = x.Password,
                Phone = x.Phone,
                RegistrationDate = x.RegistrationDate,
                UserId = x.UserId,
            }).ToList();
        }
    }
}
