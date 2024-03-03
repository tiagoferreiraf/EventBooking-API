using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
