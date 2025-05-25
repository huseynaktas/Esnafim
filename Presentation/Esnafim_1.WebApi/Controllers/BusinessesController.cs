using Esnafim_1.Application.Features.Mediator.Commands.BusinessCommands;
using Esnafim_1.Application.Features.Mediator.Queries.BusinessQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusinessesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BusinessList()
        {
            var values = await _mediator.Send(new GetBusinessQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusiness(int id)
        {
            var value = await _mediator.Send(new GetBusinessByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBusiness(CreateBusinessCommand command)
        {
            await _mediator.Send(command);
            return Ok("İşletme Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBusiness(int id)
        {
            await _mediator.Send(new RemoveBusinessCommand(id));
            return Ok("İşletme Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBusiness(UpdateBusinessCommand command)
        {
            await _mediator.Send(command);
            return Ok("İşletme Güncellendi");
        }
        [HttpGet("GetLast4BusinessList")]
        public async Task<IActionResult> GetLast4BusinessList()
        {
            var value = await _mediator.Send(new GetLast4BusinessQuery());
            return Ok(value);
        }
    }
}
