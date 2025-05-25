using Esnafim_1.Application.Features.CQRS.Commands.SocialMediaCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSocialMediaCommand command)
        {
            var values = await _repository.GetByIdAsync(command.SocialMediaId);
            values.Name = command.Name;
            values.Url = command.Url;
            values.Icon = command.Icon;
            await _repository.UpdateAsync(values);
        }
    }
}
