using Esnafim_1.Application.Features.Mediator.Queries.RoleQueries;
using Esnafim_1.Application.Features.Mediator.Results.RoleResults;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Handlers.RoleHandlers
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, GetRoleByIdQueryResult>
    {
        private readonly IRepository<Role> _repository;

        public GetRoleByIdQueryHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task<GetRoleByIdQueryResult> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetRoleByIdQueryResult
            {
                IsActive = values.IsActive,
                Name = values.Name,
                RoleId = values.RoleId,
            };
        }
    }
}
