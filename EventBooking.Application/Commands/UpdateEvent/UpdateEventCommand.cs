using EventBooking.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest<EventViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Local { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
    }
}
