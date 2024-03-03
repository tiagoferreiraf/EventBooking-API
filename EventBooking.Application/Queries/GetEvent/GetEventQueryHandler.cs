using EventBooking.Domain.Interfaces;
using EventBooking.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Queries.GetEvent
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, EventViewModel>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<EventViewModel> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var lEvent = _eventRepository.GetEvent(request.Id);
            var EventModel = new EventViewModel
            {
                Id = request.Id,
                Local = lEvent.Local,
                Capacity = lEvent.Capacity,
                Date = lEvent.Date,
                NameEvent = lEvent.Name
            };
            return Task.FromResult(EventModel);
        }
    }
}
