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
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentCommand command)
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

        [HttpGet("GetAppointmentsByBusinessId/{businessId}")]
        public async Task<IActionResult> GetAppointmentsByBusinessId(int businessId)
        {
            var result = await _mediator.Send(
                new GetAppointmentsByBusinessIdQuery(businessId));

            return Ok(result);
        }

        [HttpGet("OccupiedSlots")]
        public async Task<IActionResult> OccupiedSlots([FromQuery] int businessId, [FromQuery] int employeeId, [FromQuery] DateTime date)
        {
            var result = await _mediator.Send(new GetOccupiedSlotsQuery(businessId, employeeId, date));
            return Ok(result);
        }

        [HttpGet("GetAppointmentsByUserId/{userId}")]
        public async Task<IActionResult> GetAppointmentsByUserId(int userId)
        {
            var values = await _mediator.Send(new GetAppointmentsByUserIdQuery(userId));
            return Ok(values);
        }

        [HttpGet("GetAppointmentsByEmployeeId/{employeeId}")]
        public async Task<IActionResult> GetAppointmentsByEmployeeId(int employeeId)
        {
            var values = await _mediator.Send(new GetAppointmentsByEmployeeIdQuery(employeeId));
            return Ok(values);
        }
    }
}
