using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.Entities
{
    public class Event
    {
        public Event(string name, DateTime date, int capacity, string local)
        {
            Name = name;
            Date = date;
            Capacity = capacity;
            Local = local;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Local { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
