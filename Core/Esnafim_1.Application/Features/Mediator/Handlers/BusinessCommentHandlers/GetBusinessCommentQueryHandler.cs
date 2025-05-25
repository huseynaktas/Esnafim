using Esnafim_1.Application.Features.Mediator.Queries.BusinessCommentQueries;
using Esnafim_1.Application.Features.Mediator.Results.BusinessCommentResults;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.BusinessCommentHandlers
{
    public class GetBusinessCommentQueryHandler : IRequestHandler<GetBusinessCommentQuery, List<GetBusinessCommentQueryResult>>
    {
        private readonly IRepository<BusinessComment> _repository;

        public GetBusinessCommentQueryHandler(IRepository<BusinessComment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBusinessCommentQueryResult>> Handle(GetBusinessCommentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBusinessCommentQueryResult
            {
                BusinessCommentId = x.BusinessCommentId,
                BusinessId = x.BusinessId,
                CommentDate = x.CommentDate,
                CommentText = x.CommentText,
                IsSpam = x.IsSpam,
                UserId = x.UserId
            }).ToList();
        }
    }
}
