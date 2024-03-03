using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.Entities
{
    public class Reservation
    {
        public Reservation(int quantityTickets, DateTime reservationDate, int eventId, int userId)
        {
            QuantityTickets = quantityTickets;
            ReservationDate = reservationDate;
            EventId = eventId;
            UserId = userId;
        }

        public int Id { get; set; }
        public int QuantityTickets { get; set; }
        public DateTime ReservationDate { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public Event Event { get; set; }
        public User User { get; set; }
    }
}
