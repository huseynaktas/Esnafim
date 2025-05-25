using Esnafim_1.Application.Features.CQRS.Commands.SocialMediaCommands;
using Esnafim_1.Application.Features.CQRS.Handlers.SocialMediaHandlers;
using Esnafim_1.Application.Features.CQRS.Queries.SocialMediaQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly GetSocialMediaQueryHandler _getSocialMediaQueryHandler;
        private readonly GetSocialMediaByIdQueryHandler _getSocialMediaByIdQueryHandler;
        private readonly CreateSocialMediaCommandHandler _createSocialMediaCommandHandler;
        private readonly UpdateSocialMediaCommandHandler _updateSocialMediaCommandHandler;
        private readonly RemoveSocialMediaCommandHandler _removeSocialMediaCommandHandler;

        public SocialMediasController(GetSocialMediaQueryHandler getSocialMediaQueryHandler, GetSocialMediaByIdQueryHandler getSocialMediaByIdQueryHandler, CreateSocialMediaCommandHandler createSocialMediaCommandHandler, UpdateSocialMediaCommandHandler updateSocialMediaCommandHandler, RemoveSocialMediaCommandHandler removeSocialMediaCommandHandler)
        {
            _getSocialMediaQueryHandler = getSocialMediaQueryHandler;
            _getSocialMediaByIdQueryHandler = getSocialMediaByIdQueryHandler;
            _createSocialMediaCommandHandler = createSocialMediaCommandHandler;
            _updateSocialMediaCommandHandler = updateSocialMediaCommandHandler;
            _removeSocialMediaCommandHandler = removeSocialMediaCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _getSocialMediaQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await _getSocialMediaByIdQueryHandler.Handle(new GetSocialMediaByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await _createSocialMediaCommandHandler.Handle(command);
            return Ok("Sosyal medya bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _removeSocialMediaCommandHandler.Handle(new RemoveSocialMediaCommand(id));
            return Ok("Sosyal medya bilgisi silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await _updateSocialMediaCommandHandler.Handle(command);
            return Ok("Sosyal medya bilgisi güncellendi");
        }
    }
}
