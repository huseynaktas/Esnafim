using Esnafim_1.Application.Features.Mediator.Commands.EmployeeCommands;
using Esnafim_1.Application.Features.Mediator.Queries.EmployeeQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var values = await _mediator.Send(new GetEmployeeQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var value = await _mediator.Send(new GetEmployeeByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand command)
        {
            await _mediator.Send(command);
            return Ok("Çalışan Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            await _mediator.Send(new RemoveEmployeeCommand(id));
            return Ok("Çalışan Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeCommand command)
        {
            await _mediator.Send(command);
            return Ok("Çalışan Güncellendi");
        }

        [HttpGet("GetEmployeesByBusinessId/{businessId:int}")]
        public async Task<IActionResult> GetEmployeesByBusinessId(int businessId)
        {
            var result = await _mediator.Send(new GetEmployeeListByBusinessIdQuery(businessId));
            return Ok(result);
        }
    }
}
