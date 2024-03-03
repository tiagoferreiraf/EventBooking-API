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

namespace EventBooking.Application.Commands.AddEvent
{
    public class AddEventCommandHandler : IRequestHandler<AddEventCommand, EventViewModel>
    {
        private readonly IEventRepository _eventRepository;

        public AddEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventViewModel> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {

            ValidRequest(request);
            var lEvent = new Event(request.Name, request.Date, request.Capacity, request.Local);
            _eventRepository.Create(lEvent);
            var lEventViewModel = new EventViewModel
            {
                Local = lEvent.Local,
                Capacity = lEvent.Capacity,
                Date = lEvent.Date,
                NameEvent = lEvent.Name,
            };
            return lEventViewModel;

        }
        public void ValidRequest(AddEventCommand request)
        {
            if (string.IsNullOrEmpty(request.Name)) throw new RequestArgumentException("Nome não preenchido");
            if (string.IsNullOrEmpty(request.Local)) throw new RequestArgumentException("Local não preenchido");
            if (request.Capacity == 0) throw new RequestArgumentException("Capacidade deve ser maior que zero");
            if (request.Date < DateTime.Now) throw new RequestArgumentException("Data não pode ser menor que a data atual");
        }
    }
}
