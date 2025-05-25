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
    public class UpdateTestimonialCommandHandler
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand command)
        {
            var values = await _repository.GetByIdAsync(command.TestimonialId);
            values.Comment = command.Comment;
            values.Name = command.Name;
            values.Title = command.Title;
            values.ImageUrl = command.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
