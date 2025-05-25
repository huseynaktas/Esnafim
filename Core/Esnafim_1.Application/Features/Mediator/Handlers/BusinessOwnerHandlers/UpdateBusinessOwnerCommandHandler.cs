using Esnafim_1.Application.Features.Mediator.Commands.BusinessOwnerCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.BusinessOwnerHandlers
{
    public class UpdateBusinessOwnerCommandHandler : IRequestHandler<UpdateBusinessOwnerCommand>
    {
        private readonly IRepository<BusinessOwner> _repository;

        public UpdateBusinessOwnerCommandHandler(IRepository<BusinessOwner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBusinessOwnerCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BusinessOwnerId);
            values.PhoneNumber = request.PhoneNumber;
            values.City = request.City;
            values.Email = request.Email;
            values.Name = request.Name;
            values.Password = request.Password;
            values.RegistrationDate = request.RegistrationDate;
            values.IsActive = request.IsActive;
            await _repository.UpdateAsync(values);
        }
    }
}
