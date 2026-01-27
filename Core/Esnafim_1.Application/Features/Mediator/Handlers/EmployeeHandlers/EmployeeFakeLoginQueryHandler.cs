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
    public class EmployeeFakeLoginQueryHandler : IRequestHandler<EmployeeFakeLoginQuery, EmployeeFakeLoginQueryResult>
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeFakeLoginQueryHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<EmployeeFakeLoginQueryResult> Handle(EmployeeFakeLoginQuery request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByEmailAndPasswordAsync(request.Email, request.Password);

            if (employee == null)
                return null;

            // çalışanın bağlı olduğu ilk businessId (yoksa 0)
            var businessId = employee.BusinessEmployees?
                .Select(be => be.BusinessId)
                .FirstOrDefault() ?? 0;

            return new EmployeeFakeLoginQueryResult
            {
                EmployeeId = employee.EmployeeId,
                BusinessId = businessId,
                Name = employee.Name ?? "" // sende Name tek kolon
            };
        }
    }
}
