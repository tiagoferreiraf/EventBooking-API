using EventBooking.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Queries.GetEvent
{
    public class GetEventQuery : IRequest<EventViewModel>
    {
        public GetEventQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
