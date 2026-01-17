using Esnafim_1.Application.Features.Mediator.Queries.EmployeeQueries;
using Esnafim_1.Application.Features.Mediator.Results.EmployeeResults;
using Esnafim_1.Application.Interfaces.EmployeeInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.EmployeeHandlers
{
    public class GetEmployeeListByBusinessIdQueryHandler : IRequestHandler<GetEmployeeListByBusinessIdQuery, List<GetEmployeeListByBusinessIdQueryResult>>
    {
        private readonly IEmployeeRepository _repository;

        public GetEmployeeListByBusinessIdQueryHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetEmployeeListByBusinessIdQueryResult>> Handle(GetEmployeeListByBusinessIdQuery request, CancellationToken cancellationToken)
        {
            var employees = await _repository.GetEmployeesByBusinessIdAsync(request.Id);

            return employees.Select(x => new GetEmployeeListByBusinessIdQueryResult
            {
                EmployeeId = x.EmployeeId,
                Name = x.Name,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                ImageUrl = x.ImageUrl,
                IsActive = x.IsActive,
                RegistrationDate = x.RegistrationDate
            }).ToList();
        }
    }
}
