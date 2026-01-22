using Esnafim_1.Application.Features.Mediator.Queries.UserQueries;
using Esnafim_1.Application.Features.Mediator.Results.UserResults;
using Esnafim_1.Application.Interfaces.UserInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.UserHandlers
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, GetUserByEmailQueryResult>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByEmailQueryResult> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
                return null;

            return new GetUserByEmailQueryResult
            {
                UserId = user.UserId,
                Name = user.Name,
                Phone = user.Phone,
                City = user.City,
                District = user.District,
                Neighborhood = user.Neighborhood,
                Address = user.Address,
                Email = user.Email,
                Password = user.Password, // HASH
                IsActive = user.IsActive,
                RegistrationDate = user.RegistrationDate
            };
        }
    }
}
