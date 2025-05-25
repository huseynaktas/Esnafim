using Esnafim_1.Application.Features.Mediator.Commands.BusinessCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.BusinessHandlers
{
    public class CreateBusinessCommandHandler : IRequestHandler<CreateBusinessCommand>
    {
        private readonly IRepository<Business> _repository;

        public CreateBusinessCommandHandler(IRepository<Business> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Business
            {
                Address = request.Address,
                BusinessName = request.BusinessName,
                BusinessPhone = request.BusinessPhone,
                City = request.City,
                District = request.District,
                Email = request.Email,
                EnterpriseNumber = request.EnterpriseNumber,
                ImageUrl = request.ImageUrl,
                IsActive = request.IsActive,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Neighborhood = request.Neighborhood,
                RegistrationDate = request.RegistrationDate,
                WorkingHours = request.WorkingHours,
            });
        }
    }
}
