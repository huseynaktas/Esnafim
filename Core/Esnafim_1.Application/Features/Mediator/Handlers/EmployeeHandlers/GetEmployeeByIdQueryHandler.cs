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
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResult>
    {
        private readonly IRepository<Employee> _repository;

        public GetEmployeeByIdQueryHandler(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<GetEmployeeByIdQueryResult> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetEmployeeByIdQueryResult
            {
                EmployeeId = values.EmployeeId,
                Email = values.Email,
                ImageUrl = values.ImageUrl,
                IsActive = values.IsActive,
                Name = values.Name,
                Password = values.Password,
                PhoneNumber = values.PhoneNumber,
                RegistrationDate = values.RegistrationDate,
            };
        }
    }
}
