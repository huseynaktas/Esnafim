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
    public class GetTestimonialQueryHandler
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTestimonialQueryResult 
            { 
                TestimonialId = x.TestimonialId,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Title = x.Title
            }).ToList();
        }
    }
}
