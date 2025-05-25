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
    public class UpdateFooterAddressCommandHandler
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.FooterAddressId);
            values.PhoneNumber = command.PhoneNumber;
            values.Address = command.Address;
            values.Email = command.Email;
            values.Description = command.Description;
            await _repository.UpdateAsync(values);
        }
    }
}
