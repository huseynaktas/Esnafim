using Esnafim_1.Application.Features.Mediator.Commands.BusinessCommentCommands;
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
    public class CreateBusinessCommentCommandHandler : IRequestHandler<CreateBusinessCommentCommand>
    {
        private readonly IRepository<BusinessComment> _repository;

        public CreateBusinessCommentCommandHandler(IRepository<BusinessComment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBusinessCommentCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new BusinessComment
            {
                UserId = request.UserId,
                BusinessId = request.BusinessId,
                IsSpam = request.IsSpam,
                CommentDate = request.CommentDate,
                CommentText = request.CommentText,
            });
        }
    }
}
