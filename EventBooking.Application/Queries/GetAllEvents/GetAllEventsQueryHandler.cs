using EventBooking.Domain.Interfaces;
using EventBooking.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Queries.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, List<EventViewModel>>
    {
        private readonly IEventRepository _eventRepository;

        public GetAllEventsQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<List<EventViewModel>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var result = _eventRepository.GetAllEvents();
            List<EventViewModel> eventsList = result.Select(e => new EventViewModel
            {
                Id = e.Id,
                NameEvent = e.Name,
                Local = e.Local,
                Date = e.Date,
                Capacity = e.Capacity,
            }).ToList();
            return Task.FromResult(eventsList);
        }
    }
}
