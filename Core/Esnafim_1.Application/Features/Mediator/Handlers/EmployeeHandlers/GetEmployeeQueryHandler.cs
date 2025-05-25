using Esnafim_1.Application.Features.Mediator.Queries.EmployeeQueries;
using Esnafim_1.Application.Features.Mediator.Results.EmployeeResults;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.EmployeeHandlers
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<GetEmployeeQueryResult>>
    {
        private readonly IRepository<Employee> _repository;

        public GetEmployeeQueryHandler(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetEmployeeQueryResult>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetEmployeeQueryResult
            {
                EmployeeId = x.EmployeeId,
                Email = x.Email,
                ImageUrl = x.ImageUrl,
                IsActive = x.IsActive,
                Name = x.Name,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber,
                RegistrationDate = x.RegistrationDate
            }).ToList();
        }
    }
}
