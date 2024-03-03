using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Queries.GetAllRevervationsByUser
{
    public class GetAllReservationsByUserQueryHandler : IRequestHandler<GetAllReservationsByUserQuery, List<Reservation>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetAllReservationsByUserQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Task<List<Reservation>> Handle(GetAllReservationsByUserQuery request, CancellationToken cancellationToken)
        {
            var listReservations = _reservationRepository.GetReservationsByUser(request.Id);
            return Task.FromResult(listReservations);
        }
    }
}
