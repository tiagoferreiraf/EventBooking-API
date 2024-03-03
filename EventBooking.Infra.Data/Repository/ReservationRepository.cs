using EventBooking.Domain.Entities;
using EventBooking.Domain.Exceptions;
using EventBooking.Domain.Interfaces;
using EventBooking.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Infra.Data.Repository
{
    public class ReservationRepository : IReservationRepository
    {
         private readonly ApplicationContext _dbContext;

        public ReservationRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Reservation reservation)
        {
            try
            {
                _dbContext.Reservation.Add(reservation);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new("Ocorreu um problema ao criar uma reserva");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dbContext.Remove(id);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new("Ocorreu um problema ao deletar a reserva");
            }
           
        }

        public Reservation GetReservation(int id)
        {
            try
            {
                var lReservation = _dbContext.Reservation.Where(x => x.Id == id).FirstOrDefault();
                if (lReservation == null) throw new NotFoundException("Reserva não encontrada");
                return lReservation;
            }
            catch (Exception)
            {
                throw new("Ocorreu um problema ao buscar a reserva");
            }
        }


        public List<Reservation> GetReservationsByUser(int userId)
        {
            try
            {
                var listReservations = _dbContext.Reservation.Where(x => x.UserId == userId).ToList();
                if (listReservations == null) throw new NotFoundException("Reservas não encontrada");
                return listReservations;
            }
            catch (Exception)
            {
                throw new("Ocorreu um problema ao buscar reservas");
            }
        
        }

        public Reservation Update(int id, Reservation reservation)
        {
            var lReservation = _dbContext.Reservation.FirstOrDefault(x => x.Id == id);
            if (lReservation == null) throw new NotFoundException("Reserva não encontrado");
            lReservation.ReservationDate = reservation.ReservationDate;
            lReservation.QuantityTickets = reservation.QuantityTickets;
            _dbContext.Reservation.Update(lReservation);
            _dbContext.SaveChanges();
            return lReservation;
        }
    }
}
