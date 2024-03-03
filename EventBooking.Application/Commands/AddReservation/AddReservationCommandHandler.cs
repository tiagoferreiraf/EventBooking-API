using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Commands.AddReservation
{
 
    public class AddReservationCommandHandler : IRequestHandler<AddReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;

        public AddReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Task<Unit> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            var lReservation = new Reservation(request.QuantityTickets, request.ReservationDate, request.EventId, request.UserId);
            _reservationRepository.Create(lReservation);
            return Task.FromResult(Unit.Value);
        }
    }
}
