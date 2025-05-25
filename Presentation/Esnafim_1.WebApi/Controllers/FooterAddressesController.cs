using Esnafim_1.Application.Features.CQRS.Commands.FooterAddressCommands;
using Esnafim_1.Application.Features.CQRS.Handlers.FooterAddressHandlers;
using Esnafim_1.Application.Features.CQRS.Queries.FooterAddressQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly GetFooterAddressQueryHandler _getFooterAddressQueryHandler;
        private readonly GetFooterAddressByIdQueryHandler _getFooterAddressByIdQueryHandler;
        private readonly CreateFooterAddressCommandHandler _createFooterAddressCommandHandler;
        private readonly UpdateFooterAddressCommandHandler _updateFooterAddressCommandHandler;
        private readonly RemoveFooterAddressCommandHandler _removeFooterAddressCommandHandler;

        public FooterAddressesController(GetFooterAddressQueryHandler getFooterAddressQueryHandler, GetFooterAddressByIdQueryHandler getFooterAddressByIdQueryHandler, CreateFooterAddressCommandHandler createFooterAddressCommandHandler, UpdateFooterAddressCommandHandler updateFooterAddressCommandHandler, RemoveFooterAddressCommandHandler removeFooterAddressCommandHandler)
        {
            _getFooterAddressQueryHandler = getFooterAddressQueryHandler;
            _getFooterAddressByIdQueryHandler = getFooterAddressByIdQueryHandler;
            _createFooterAddressCommandHandler = createFooterAddressCommandHandler;
            _updateFooterAddressCommandHandler = updateFooterAddressCommandHandler;
            _removeFooterAddressCommandHandler = removeFooterAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var values = await _getFooterAddressQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var value = await _getFooterAddressByIdQueryHandler.Handle(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _createFooterAddressCommandHandler.Handle(command);
            return Ok("Footer Adres bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _removeFooterAddressCommandHandler.Handle(new RemoveFooterAddressCommand(id));
            return Ok("Footer Adres bilgisi silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _updateFooterAddressCommandHandler.Handle(command);
            return Ok("Footer Adres bilgisi güncellendi");
        }
    }
}
