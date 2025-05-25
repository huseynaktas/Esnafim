using Esnafim_1.Application.Features.CQRS.Queries.FooterAddressQueries;
using Esnafim_1.Application.Features.CQRS.Results.FooterAddressResults;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetFooterAddressByIdQueryResult
            {
                FooterAddressId = values.FooterAddressId,
                Address = values.Address,
                Description = values.Description,
                Email = values.Email,
                PhoneNumber = values.PhoneNumber
            };
        }
    }
}
