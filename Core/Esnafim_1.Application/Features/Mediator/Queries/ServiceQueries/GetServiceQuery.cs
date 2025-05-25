using Esnafim_1.Application.Features.Mediator.Results.ServiceResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceQuery: IRequest<List<GetServiceQueryResult>>
    {
    }
}
