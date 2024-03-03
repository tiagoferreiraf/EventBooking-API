using EventBooking.Domain.Entities;
using EventBooking.Domain.Exceptions;
using EventBooking.Domain.Interfaces;
using EventBooking.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Infra.Data.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationContext _dbContext;

        public EventRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Event pEvent)
        {
            try
            {
                _dbContext.Event.Add(pEvent);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new("Ocorreu um problema ao criar um usuário");
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
                throw new("Ocorreu um problema ao deletar um usuário");
            }

        }

        public List<Event> GetAllEvents()
        {
            try
            {
                var lEvents = _dbContext.Event.ToList();
                return lEvents;
            }
            catch (Exception)
            {
                throw new("Ocorreu um problema ao buscar evento");
            }
            
        }

        public Event GetEvent(int id)
        {
            try
            {
                var lEvent = _dbContext.Event.Where(x => x.Id == id).FirstOrDefault();
                if (lEvent == null) throw new NotFoundException("Evento não encontrado");
                return lEvent;
            }
            catch (Exception)
            {
                throw new("Ocorreu um problema ao buscar o usuário");
            }
            
        }

        public Event Update(int id, Event pEvent)
        {
            try
            {
                var lEvent = _dbContext.Event.FirstOrDefault(x => x.Id == id);
                if(lEvent == null) throw new NotFoundException("Evento não encontrado");
                lEvent.Name = pEvent.Name;
                lEvent.Local = pEvent.Local;
                lEvent.Capacity = pEvent.Capacity;
                lEvent.Date = pEvent.Date;

                _dbContext.Event.Update(lEvent);
                _dbContext.SaveChanges();
                return lEvent;
            }
            catch (Exception)
            {
                throw new("Ocorreu um problema ao atualizar os dados do usuário");
            }
            
        }
    }
}
