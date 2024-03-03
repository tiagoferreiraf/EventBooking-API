using EventBooking.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Commands.UpdateReservation
{
    public class UpdateReservationCommand : IRequest<ReservationViewModel>
    {
        public int Id { get; set; }
        public int QuantityTickets { get; set; }
        public DateTime ReservationDate { get; set; }
        
    }
}
