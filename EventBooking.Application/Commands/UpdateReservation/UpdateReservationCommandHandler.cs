﻿using EventBooking.Domain.Entities;
using EventBooking.Domain.Exceptions;
using EventBooking.Domain.Interfaces;
using EventBooking.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Commands.UpdateReservation
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, ReservationViewModel>
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Task<ReservationViewModel> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {

            var lReservation = _reservationRepository.GetReservation(request.Id);
            lReservation.ReservationDate = request.ReservationDate;
            lReservation.QuantityTickets = request.QuantityTickets;
            var response = _reservationRepository.Update(request.Id, lReservation);

            var reservationModel = new ReservationViewModel
            {
               Id = response.Id,
               QuantityTickets = response.QuantityTickets,
               ReservationDate = response.ReservationDate,
            };
            return Task.FromResult(reservationModel);
        }
    }
}
