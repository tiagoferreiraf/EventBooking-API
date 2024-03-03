using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Commands.AddReservation
{
    public class AddReservationCommand : IRequest<Unit>
    {
        public int QuantityTickets { get; set; }
        public DateTime ReservationDate { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
