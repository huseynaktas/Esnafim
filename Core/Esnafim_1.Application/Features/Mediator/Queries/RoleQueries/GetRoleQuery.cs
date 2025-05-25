using Esnafim_1.Application.Features.Mediator.Results.RoleResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Queries.RoleQueries
{
    public class GetRoleQuery: IRequest<List<GetRoleQueryResult>>
    {
    }
}
