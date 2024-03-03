using EventBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.Interfaces
{
    public interface IReservationRepository
    {
        void Create(Reservation reservation);
        Reservation Update(int id, Reservation reservation);
        void Delete(int id);
        List<Reservation> GetReservationsByUser(int userId);
        Reservation GetReservation(int id);
    }
}
