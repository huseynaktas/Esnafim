using Esnafim_1.Application.Features.Mediator.Results.BusinessResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Queries.BusinessQueries
{
    public class GetLast4BusinessQuery: IRequest<List<GetLast4BusinessQueryResult>>
    {
    }
}
