using Esnafim_1.Application.Features.Mediator.Results.EmployeeResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Queries.EmployeeQueries
{
    public class GetEmployeeQuery: IRequest<List<GetEmployeeQueryResult>>
    {
    }
}
