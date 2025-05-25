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
    public class GetFooterAddressQueryHandler
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            {
                FooterAddressId = x.FooterAddressId,
                Address = x.Address,
                Description = x.Description,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
            }).ToList();
        }
    }
}
