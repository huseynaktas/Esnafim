using Esnafim_1.Application.Features.Mediator.Commands.BusinessCommentCommands;
using Esnafim_1.Application.Features.Mediator.Queries.BusinessCommentQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessCommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusinessCommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BusinessCommentList()
        {
            var values = await _mediator.Send(new GetBusinessCommentQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusinessComment(int id)
        {
            var value = await _mediator.Send(new GetBusinessCommentByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBusinessComment(CreateBusinessCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("İşletme Sahibi Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBusinessComment(int id)
        {
            await _mediator.Send(new RemoveBusinessCommentCommand(id));
            return Ok("İşletme Sahibi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBusinessComment(UpdateBusinessCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("İşletme Sahibi Güncellendi");
        }
    }
}
