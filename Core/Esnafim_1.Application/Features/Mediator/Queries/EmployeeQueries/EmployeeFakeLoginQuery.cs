using Esnafim_1.Application.Features.Mediator.Results.EmployeeResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Queries.EmployeeQueries
{
    public class EmployeeFakeLoginQuery: IRequest<EmployeeFakeLoginQueryResult>
    {
        public EmployeeFakeLoginQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
