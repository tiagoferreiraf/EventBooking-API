using EventBooking.Application.Commands.AddUser;
using EventBooking.Application.Queries.AuthorizeUser;
using EventBooking.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]AddUserCommand user)
        {
            var result = await _mediator.Send(user);
            if (result == null) return BadRequest();
            return Ok(new 
            { 
                token = result
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthorizeUserQuery user)
        {
            var result = await _mediator.Send(user);
            if (result == null) return BadRequest();
            return Ok(new
            {
                token = result
            });
        }
    }
}
