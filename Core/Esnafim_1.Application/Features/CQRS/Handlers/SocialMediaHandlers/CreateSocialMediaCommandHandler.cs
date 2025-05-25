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
    public class CreateSocialMediaCommandHandler
    {
        private readonly IRepository<SocialMedia> _repository;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateSocialMediaCommand command)
        {
            await _repository.CreateAsync(new SocialMedia
            {
                Url = command.Url,
                Icon = command.Icon,
                Name = command.Name
            });
        }
    }
}
