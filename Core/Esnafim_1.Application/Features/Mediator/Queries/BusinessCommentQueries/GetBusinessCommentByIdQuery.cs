using Esnafim_1.Application.Features.Mediator.Results.BusinessCommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Queries.BusinessCommentQueries
{
    public class GetBusinessCommentByIdQuery: IRequest<GetBusinessCommentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetBusinessCommentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
