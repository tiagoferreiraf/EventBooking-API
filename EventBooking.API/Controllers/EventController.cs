using EventBooking.Application.Commands.AddEvent;
using EventBooking.Application.Commands.DeleteEvent;
using EventBooking.Application.Commands.UpdateEvent;
using EventBooking.Application.Queries.GetAllEvents;
using EventBooking.Application.Queries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]AddEventCommand pEvent)
        {
           _mediator.Send(pEvent);
            return Created();
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetEvents()
        {
                var query = new GetAllEventsQuery();
                var response = await _mediator.Send(query);
                if (response == null) return BadRequest();
                return Ok(response);
        }

        [HttpGet("GetEvent/{id}")]
        [Authorize]
        public async Task<IActionResult> GetEvent(int id)
        {
            var query = new GetEventQuery(id);
            var response = await _mediator.Send(query);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpPut("Update/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] UpdateEventCommand Event)
        {
            Event.Id = id;
            var response = await _mediator.Send(Event);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new GetEventQuery(id);
            var response = await _mediator.Send(query);
            if (response == null) return BadRequest();
            return Ok(response);
        }
    }
}
