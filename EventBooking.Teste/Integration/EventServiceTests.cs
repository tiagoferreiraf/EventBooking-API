using EventBooking.Application.Commands.AddEvent;
using EventBooking.Application.Queries.GetEvent;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using EventBooking.Infra.Data.Context;
using EventBooking.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Teste.Integration
{
    [TestClass]
    public class EventServiceTests
    {

        private readonly ApplicationContext _context;
        //public EventServiceTests(ApplicationContext context)
        //{
        //    _context = context;
        //}

        [TestMethod]
        public async Task QuandoCommandValidoEntaoRetornarEvent()
        {
            //Arrange
            var connectionstring = "Server=127.0.0.1;Database=mysql_Eventbooking;Uid=root;Pwd=root;";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring));

            using (var dbContext = new ApplicationContext(optionsBuilder.Options))
            {
                var eventRepository = new EventRepository(dbContext);
                var handlerCommand = new AddEventCommandHandler(eventRepository);
                string eventName = "Evento4";
                //// Act - Executa o manipulador de comando para persistir um novo evento
                var command = new AddEventCommand
                {
                    Local = "Pampulha",
                    Date = new DateTime(2024, 03, 12),
                    Capacity = 10,
                    Name = eventName,
                };
                var resultCommand = await handlerCommand.Handle(command, CancellationToken.None);

                // Assert - Verifica se o evento foi persistido corretamente
                Assert.IsNotNull(resultCommand);

                // Recupera o evento do banco de dados
                var handleQuery = new GetEventQueryHandler(eventRepository);
                var @event =  handleQuery.GetEventByName(eventName);
                var getEventQuery = new GetEventQuery(@event.Id);
                var resultQuery = await handleQuery.Handle(getEventQuery, CancellationToken.None);



                //Assert - Verifica se o evento foi recuperado corretamente do banco de dados
                Assert.IsNotNull(resultQuery);
                Assert.AreEqual(command.Local, resultQuery.Local);
                Assert.AreEqual(command.Date, resultQuery.Date);
                Assert.AreEqual(command.Capacity, resultQuery.Capacity);
                Assert.AreEqual(command.Name, resultQuery.NameEvent);

            }

        }
    }
}
