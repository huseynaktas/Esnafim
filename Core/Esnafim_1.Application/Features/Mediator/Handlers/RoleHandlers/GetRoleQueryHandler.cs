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
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, List<GetRoleQueryResult>>
    {
        private readonly IRepository<Role> _repository;

        public GetRoleQueryHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRoleQueryResult>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetRoleQueryResult
            {
                RoleId = x.RoleId,
                IsActive = x.IsActive,
                Name = x.Name,
            }).ToList();
        }
    }
}
