using Esnafim_1.Application.Features.CQRS.Commands.TestimonialCommands;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.CQRS.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler
    {
        private readonly IRepository<Testimonial> _repository;

        public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestimonialCommand command)
        {
            await _repository.CreateAsync(new Testimonial
            {
                ImageUrl = command.ImageUrl,
                Comment = command.Comment,
                Name = command.Name,
                Title = command.Title
            });
        }
    }
}
