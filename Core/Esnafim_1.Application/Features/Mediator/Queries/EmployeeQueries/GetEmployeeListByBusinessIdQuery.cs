using Esnafim_1.Application.Features.Mediator.Results.EmployeeResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Queries.EmployeeQueries
{
    public class GetEmployeeListByBusinessIdQuery: IRequest<List<GetEmployeeListByBusinessIdQueryResult>>
    {
        public int Id { get; set; }

        public GetEmployeeListByBusinessIdQuery(int id)
        {
            Id = id;
        }
    }
}
