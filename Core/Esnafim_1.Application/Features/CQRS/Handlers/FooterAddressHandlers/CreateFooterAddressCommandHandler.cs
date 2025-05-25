using Esnafim_1.Application.Features.CQRS.Commands.FooterAddressCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler
    {
        private readonly IRepository<FooterAddress> _repository;

        public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterAddressCommand command)
        {
            await _repository.CreateAsync(new FooterAddress
            {
                Address = command.Address,
                Description = command.Description,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
            });
        }
    }
}
