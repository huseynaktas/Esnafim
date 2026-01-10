using Esnafim_1.Application.Features.Mediator.Commands.BusinessOwnerCommands;
using Esnafim_1.Application.Features.Mediator.Queries.BusinessOwnerQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessOwnersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusinessOwnersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BusinessOwnerList()
        {
            var values = await _mediator.Send(new GetBusinessOwnerQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusinessOwner(int id)
        {
            var value = await _mediator.Send(new GetBusinessOwnerByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBusinessOwner(CreateBusinessOwnerCommand command)
        {
            await _mediator.Send(command);
            return Ok("İşletme Sahibi Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBusinessOwner(int id)
        {
            await _mediator.Send(new RemoveBusinessOwnerCommand(id));
            return Ok("İşletme Sahibi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBusinessOwner(UpdateBusinessOwnerCommand command)
        {
            await _mediator.Send(command);
            return Ok("İşletme Sahibi Güncellendi");
        }

        [HttpGet("GetBusinessByBusinessOwnerId")]
        public async Task<IActionResult> GetBusinessByBusinessOwnerId()
        {
            var result = await _mediator.Send(new GetBusinessesByOwnerIdQuery());
            return Ok(result);
        }
    }


}
