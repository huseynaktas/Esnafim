using Esnafim_1.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Esnafim_1.Dto.FakeLoginDtos.FakeAuthDto;

namespace Esnafim_1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeAuthController : ControllerBase
    {
        private readonly EsnafimContext _context;

        public FakeAuthController(EsnafimContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] FakeLoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Email ve şifre zorunlu.");

            var owner = await _context.BusinessOwner
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password);

            if (owner is null)
                return Unauthorized("Email veya şifre hatalı.");

            var fullName = $"{owner.Name}".Trim();

            return Ok(new FakeLoginResponse(owner.BusinessOwnerId, owner.Email, fullName));
        }
    }
}
