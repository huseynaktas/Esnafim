using Esnafim_1.Application.Features.Mediator.Commands.UserCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.UserHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IRepository<User> _repository;

        public UpdateUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.UserId);
            values.Address = request.Address;
            values.Password = request.Password;
            values.Email = request.Email;
            values.District = request.District;
            values.Phone = request.Phone;
            values.City = request.City;
            values.IsActive = request.IsActive;
            values.RegistrationDate = request.RegistrationDate;
            values.Name = request.Name;
            values.Neighborhood = request.Neighborhood;
            await _repository.UpdateAsync(values);
        }
    }
}
