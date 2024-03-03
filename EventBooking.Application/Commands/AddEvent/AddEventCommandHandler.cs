using EventBooking.Domain.Entities;
using EventBooking.Domain.Exceptions;
using EventBooking.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Commands.AddEvent
{
    public class AddEventCommandHandler : IRequestHandler<AddEventCommand, Unit>
    {
        private readonly IEventRepository _eventRepository;

        public AddEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<Unit> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null) throw new Exception("campos vazios");
                var lEvent = new Event(request.Name, request.Date, request.Capacity, request.Local);
                _eventRepository.Create(lEvent);
                return Task.FromResult(Unit.Value);
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
