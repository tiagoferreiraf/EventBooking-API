using EventBooking.Application.Commands.AddReservation;
using EventBooking.Application.Commands.UpdateReservation;
using EventBooking.Application.Queries.GetAllRevervationsByUser;
using EventBooking.Application.Queries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] AddReservationCommand reservation)
        {
            _mediator.Send(reservation);
            return Ok();
        }

        [HttpGet("GetAllReservationsByUser/{id}")]
        [Authorize]
        public async Task<IActionResult> GetAllReservations(int id)
        {
            var query = new GetAllReservationsByUserQuery(id);
            var response = _mediator.Send(query);
            if (response == null) return BadRequest();
            return Ok(response);
        }
        [HttpPut("Update/{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateReservationCommand reservation)
        {
            reservation.Id = id;
            var response = await _mediator.Send(reservation);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
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
