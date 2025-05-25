using Esnafim_1.Application.Features.CQRS.Queries.TestimonialQueries;
using Esnafim_1.Application.Features.CQRS.Results.TestimonialResults;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.CQRS.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetTestimonialByIdQueryResult
            {
                TestimonialId = values.TestimonialId,
                Comment = values.Comment,
                ImageUrl = values.ImageUrl,
                Name = values.Name,
                Title = values.Title
            };
        }
    }
}
