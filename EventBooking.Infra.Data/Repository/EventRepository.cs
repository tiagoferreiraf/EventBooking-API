using EventBooking.Domain.Entities;
using EventBooking.Domain.Exceptions;
using EventBooking.Domain.Interfaces;
using EventBooking.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
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

            if (GetEventByName(pEvent.Name) != null) throw new Exception("Já existe um evento criado com esse nome");
            _dbContext.Event.Add(pEvent);
            _dbContext.SaveChangesAsync();
            ;
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
                throw new("Ocorreu um problema ao deletar um evento");
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
            var lEvent = _dbContext.Event.Where(x => x.Id == id).FirstOrDefault();
            if (lEvent == null) throw new NotFoundException("Evento não encontrado");
            return lEvent;
        }

        public Event GetEventByName(string nameEvent)
        {

            var lEvent = _dbContext.Event.Where(e => e.Name.Equals(nameEvent)).FirstOrDefault();
            return lEvent;

        }

        public Event Update(int id, Event pEvent)
        {
            var lEvent = _dbContext.Event.FirstOrDefault(x => x.Id == id);
            if (lEvent == null) throw new NotFoundException("Evento não encontrado");
            lEvent.Name = pEvent.Name;
            lEvent.Local = pEvent.Local;
            lEvent.Capacity = pEvent.Capacity;
            lEvent.Date = pEvent.Date;

            _dbContext.Event.Update(lEvent);
            _dbContext.SaveChanges();
            return lEvent;

        }
    }
}
