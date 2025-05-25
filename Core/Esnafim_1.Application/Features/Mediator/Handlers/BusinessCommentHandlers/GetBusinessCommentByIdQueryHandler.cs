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
    public class GetBusinessCommentByIdQueryHandler : IRequestHandler<GetBusinessCommentByIdQuery, GetBusinessCommentByIdQueryResult>
    {
        private readonly IRepository<BusinessComment> _repository;

        public GetBusinessCommentByIdQueryHandler(IRepository<BusinessComment> repository)
        {
            _repository = repository;
        }

        public async Task<GetBusinessCommentByIdQueryResult> Handle(GetBusinessCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetBusinessCommentByIdQueryResult
            {
                BusinessCommentId = values.BusinessCommentId,
                BusinessId = values.BusinessId,
                CommentDate = values.CommentDate,
                CommentText = values.CommentText,
                IsSpam = values.IsSpam,
                UserId = values.UserId,
            };
        }
    }
}
