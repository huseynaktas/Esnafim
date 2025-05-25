using Esnafim_1.Application.Features.CQRS.Commands.ContactCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var values = await _repository.GetByIdAsync(command.ContactId);
            values.Email = command.Email;
            values.Name = command.Name;
            values.Subject = command.Subject;
            values.Message = command.Message;
            values.SendDate = command.SendDate;
            await _repository.UpdateAsync(values);
        }
    }
}
