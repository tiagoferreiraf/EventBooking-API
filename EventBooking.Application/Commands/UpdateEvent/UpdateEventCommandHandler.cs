﻿using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using EventBooking.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, EventViewModel>
    {
        private readonly IEventRepository _eventRepository;

        public UpdateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<EventViewModel> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var lEvent = new Event(request.Name, request.Date, request.Capacity, request.Local);
            var response = _eventRepository.Update(request.Id,lEvent);
            var EventModel = new EventViewModel
            {
                NameEvent = response.Name,
                Capacity = response.Capacity,
                Date = response.Date,
                Local = response.Local,
                Id = response.Id,
            };
            return Task.FromResult(EventModel);
        }
    }
}
