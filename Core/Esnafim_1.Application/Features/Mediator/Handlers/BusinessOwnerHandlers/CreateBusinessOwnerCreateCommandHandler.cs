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
    public class CreateBusinessOwnerCreateCommandHandler : IRequestHandler<CreateBusinessOwnerCommand>
    {
        private readonly IRepository<BusinessOwner> _repository;

        public CreateBusinessOwnerCreateCommandHandler(IRepository<BusinessOwner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBusinessOwnerCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new BusinessOwner
            {
                Name = request.Name,
                RegistrationDate = request.RegistrationDate,
                PhoneNumber = request.PhoneNumber,
                City = request.City,
                Email = request.Email,
                IsActive = request.IsActive,
                Password = request.Password
            });
        }
    }
}
