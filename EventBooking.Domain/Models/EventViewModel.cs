using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string NameEvent { get; set; }
        public string Local { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
    }
}
