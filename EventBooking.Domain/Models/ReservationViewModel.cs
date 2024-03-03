using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public int QuantityTickets { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
