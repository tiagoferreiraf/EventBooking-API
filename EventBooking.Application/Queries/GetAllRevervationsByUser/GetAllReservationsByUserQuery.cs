using EventBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Queries.GetAllRevervationsByUser
{
    public class GetAllReservationsByUserQuery : IRequest<List<Reservation>>
    {
        public GetAllReservationsByUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
