using EventBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.Interfaces
{
    public interface IEventRepository
    {
        void Create(Event pEvent);
        Event Update(int id, Event pEvent);
        void Delete(int id);
        List<Event> GetAllEvents();
        Event GetEvent(int id);

        Event GetEventByName(string nameEvent);


    }
}
