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
    public class UpdateBusinessCommandHandler : IRequestHandler<UpdateBusinessCommand>
    {
        private readonly IRepository<Business> _repository;

        public UpdateBusinessCommandHandler(IRepository<Business> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BusinessId);
            values.BusinessName = request.BusinessName;
            values.BusinessPhone = request.BusinessPhone;
            values.Address = request.Address;
            values.City = request.City;
            values.District = request.District;
            values.Email = request.Email;
            values.EnterpriseNumber = request.EnterpriseNumber;
            values.ImageUrl = request.ImageUrl;
            values.IsActive = request.IsActive;
            values.Latitude = request.Latitude;
            values.Longitude = request.Longitude;
            values.Neighborhood = request.Neighborhood;
            values.RegistrationDate = request.RegistrationDate;
            values.WorkingHours = request.WorkingHours;
            await _repository.UpdateAsync(values);
        }
    }
}
