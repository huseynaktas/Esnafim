using Esnafim_1.Application.Features.Mediator.Results.BusinessCategoryResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Queries.BusinessCategoryQueries
{
    public class GetBusinessCategoryQuery: IRequest<List<GetBusinessCategoryQueryResult>>
    {
    }
}
