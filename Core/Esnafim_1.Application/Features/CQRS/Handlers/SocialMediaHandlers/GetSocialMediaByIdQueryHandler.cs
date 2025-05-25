using Esnafim_1.Application.Features.CQRS.Queries.SocialMediaQueries;
using Esnafim_1.Application.Features.CQRS.Results.SocialMediaResults;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetSocialMediaByIdQueryResult
            {
                SocialMediaId = values.SocialMediaId,
                Name = values.Name,
                Icon = values.Icon,
                Url = values.Url
            };
        }
    }
}
