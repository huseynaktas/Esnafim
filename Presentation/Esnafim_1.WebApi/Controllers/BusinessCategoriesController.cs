using Esnafim_1.Application.Features.Mediator.Commands.BusinessCategoryCommands;
using Esnafim_1.Application.Features.Mediator.Queries.BusinessCategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusinessCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BusinessCategoryList()
        {
            var values = await _mediator.Send(new GetBusinessCategoryQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusinessCategory(int id)
        {
            var value = await _mediator.Send(new GetBusinessCategoryByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBusinessCategory(CreateBusinessCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok("İş Kategorisi Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBusinessCategory(int id)
        {
            await _mediator.Send(new RemoveBusinessCategoryCommand(id));
            return Ok("İş Kategorisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBusinessCategory(UpdateBusinessCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok("İş Kategorisi Güncellendi");
        }
    }
}
