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
    public class UpdateBusinessCommentCommandHandler : IRequestHandler<UpdateBusinessCommentCommand>
    {
        private readonly IRepository<BusinessComment> _repository;

        public UpdateBusinessCommentCommandHandler(IRepository<BusinessComment> repository)
        {
            _repository = repository;
        }


        public async Task Handle(UpdateBusinessCommentCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BusinessCommentId);
            values.BusinessCommentId = request.BusinessCommentId;
            values.UserId = request.UserId;
            values.BusinessId = request.BusinessId;
            values.CommentDate = request.CommentDate;
            values.CommentText = request.CommentText;
            values.IsSpam = request.IsSpam;
            await _repository.UpdateAsync(values);
        }
    }
}
