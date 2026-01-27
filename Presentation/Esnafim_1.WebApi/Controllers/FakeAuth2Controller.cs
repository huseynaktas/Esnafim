using Esnafim_1.Application.Features.Mediator.Queries.EmployeeQueries;
using Esnafim_1.Application.Features.Mediator.Results.EmployeeResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebApi.Controllers
{
    [Route("api/fakeauth2")]
    [ApiController]
    public class FakeAuth2Controller : ControllerBase
    {
        private readonly IMediator _mediator;

        public FakeAuth2Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] EmployeeFakeLoginQuery request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Email ve şifre zorunlu.");

            var result = await _mediator.Send(new EmployeeFakeLoginQuery(request.Email, request.Password));

            if (result == null)
                return Unauthorized("Email veya şifre hatalı.");

            return Ok(result);
        }
    }
}
