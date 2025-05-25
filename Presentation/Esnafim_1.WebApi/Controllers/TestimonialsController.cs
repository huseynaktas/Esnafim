using Esnafim_1.Application.Features.CQRS.Commands.TestimonialCommands;
using Esnafim_1.Application.Features.CQRS.Handlers.TestimonialHandlers;
using Esnafim_1.Application.Features.CQRS.Queries.TestimonialQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly GetTestimonialQueryHandler _getTestimonialQueryHandler;
        private readonly GetTestimonialByIdQueryHandler _getTestimonialByIdQueryHandler;
        private readonly CreateTestimonialCommandHandler _createTestimonialCommandHandler;
        private readonly UpdateTestimonialCommandHandler _updateTestimonialCommandHandler;
        private readonly RemoveTestimonialCommandHandler _removeTestimonialCommandHandler;

        public TestimonialsController(GetTestimonialQueryHandler getTestimonialQueryHandler, GetTestimonialByIdQueryHandler getTestimonialByIdQueryHandler, CreateTestimonialCommandHandler createTestimonialCommandHandler, UpdateTestimonialCommandHandler updateTestimonialCommandHandler, RemoveTestimonialCommandHandler removeTestimonialCommandHandler)
        {
            _getTestimonialQueryHandler = getTestimonialQueryHandler;
            _getTestimonialByIdQueryHandler = getTestimonialByIdQueryHandler;
            _createTestimonialCommandHandler = createTestimonialCommandHandler;
            _updateTestimonialCommandHandler = updateTestimonialCommandHandler;
            _removeTestimonialCommandHandler = removeTestimonialCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _getTestimonialQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await _getTestimonialByIdQueryHandler.Handle(new GetTestimonialByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await _createTestimonialCommandHandler.Handle(command);
            return Ok("Testimonial bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _removeTestimonialCommandHandler.Handle(new RemoveTestimonialCommand(id));
            return Ok("Testimonial bilgisi silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await _updateTestimonialCommandHandler.Handle(command);
            return Ok("Testimonial bilgisi güncellendi");
        }
    }
}
