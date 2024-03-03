using EventBooking.Application.Commands.AddEvent;
using EventBooking.Application.Commands.AddUser;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Exceptions;
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
            ValidRequest(request);
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
        public void ValidRequest(UpdateEventCommand request)
        {
            if (string.IsNullOrEmpty(request.Name)) throw new RequestArgumentException("Nome não preenchido");
            if (string.IsNullOrEmpty(request.Local)) throw new RequestArgumentException("Local não preenchido");
            if (request.Capacity == 0) throw new RequestArgumentException("Capacidade deve ser maior que zero");
            if (request.Date < DateTime.Now) throw new RequestArgumentException("Data não pode ser menor que a data atual");
        }
    }
}
