using Esnafim_1.Application.Features.Mediator.Results.BusinessOwnerResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Queries.BusinessOwnerQueries
{
    public class GetBusinessOwnerByIdQuery: IRequest<GetBusinessOwnerByIdQueryResult>
    {
        public int Id { get; set; }

        public GetBusinessOwnerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
