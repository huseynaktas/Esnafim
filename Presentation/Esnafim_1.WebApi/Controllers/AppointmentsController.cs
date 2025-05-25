using Esnafim_1.Application.Features.Mediator.Commands.AppointmentCommands;
using Esnafim_1.Application.Features.Mediator.Queries.AppointmentQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AppointmentList()
        {
            var values = await _mediator.Send(new GetAppointmentQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var value = await _mediator.Send(new GetAppointmentByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Randevu Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAppointment(int id)
        {
            await _mediator.Send(new RemoveAppointmentCommand(id));
            return Ok("Randevu Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Randevu Güncellendi");
        }
    }
}
