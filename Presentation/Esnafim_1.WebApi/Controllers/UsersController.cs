using Esnafim_1.Application.Features.Mediator.Commands.UserCommands;
using Esnafim_1.Application.Features.Mediator.Queries.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var values = await _mediator.Send(new GetUserQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var value = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveUser(int id)
        {
            await _mediator.Send(new RemoveUserCommand(id));
            return Ok("Kullanıcı Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı Güncellendi");
        }
    }
}
