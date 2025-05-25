using Esnafim_1.Application.Features.Mediator.Commands.RoleCommands;
using Esnafim_1.Application.Features.Mediator.Queries.RoleQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> RoleList()
        {
            var values = await _mediator.Send(new GetRoleQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var value = await _mediator.Send(new GetRoleByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rol Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveRole(int id)
        {
            await _mediator.Send(new RemoveRoleCommand(id));
            return Ok("Rol Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rol Güncellendi");
        }
    }
}
