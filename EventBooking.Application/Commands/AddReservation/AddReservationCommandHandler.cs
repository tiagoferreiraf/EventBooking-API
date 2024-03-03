using EventBooking.Application.Commands.AddEvent;
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

namespace EventBooking.Application.Commands.AddReservation
{
 
    public class AddReservationCommandHandler : IRequestHandler<AddReservationCommand, ReservationViewModel>
    {
        private readonly IReservationRepository _reservationRepository;

        public AddReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Task<ReservationViewModel> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            ValidRequest(request);
            var lReservation = new Reservation(request.QuantityTickets, request.ReservationDate, request.EventId, request.UserId);
            _reservationRepository.Create(lReservation);
            var lReservationViewModel = new ReservationViewModel
            {
                QuantityTickets = request.QuantityTickets,
                ReservationDate = request.ReservationDate,
            };
            return Task.FromResult(lReservationViewModel);
        }
        public void ValidRequest(AddReservationCommand request)
        {
            if (request.QuantityTickets == 0) throw new RequestArgumentException("Quantidade de tickets deve ser maior que zero"); ;
            if (request.EventId == 0 ) throw new RequestArgumentException("evento não referenciado");
            if (request.UserId == 0) throw new RequestArgumentException("Usuario não referenciado");
            if (request.ReservationDate < DateTime.Now) throw new RequestArgumentException("Data não pode ser menor que a data atual");
        }
    }
}
