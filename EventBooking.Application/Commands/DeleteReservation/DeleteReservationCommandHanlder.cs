using EventBooking.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Commands.DeleteReservation
{
    public class DeleteReservationCommandHanlder : IRequestHandler<DeleteReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;

        public DeleteReservationCommandHanlder(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            _reservationRepository.Delete(request.Id);
            return Task.FromResult(Unit.Value);
        }
    }
}
