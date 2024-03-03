using AutoFixture;
using EventBooking.Application.Commands.AddEvent;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Exceptions;
using EventBooking.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Teste.Unity
{
    [TestClass]
    public class EventServiceTests
    {
        [TestMethod]
        public async Task QuandoCommandDataInvalidaEntaoRetornarException()
        {

            //Arrange
            //var command = new Fixture().Create<AddEventCommand>();
            var mockCommand = new AddEventCommand
            {
                Capacity = 10,
                Date = new DateTime(2022, 10, 13),
                Local = "dasdsadsa",
                Name = "dsadsad",
            };

            var eventRepositoryMock = new Mock<IEventRepository>();

            var eventService = new AddEventCommandHandler(eventRepositoryMock.Object);

            var cancellationToken = new CancellationToken();

            //Act
            var ex = await Assert.ThrowsExceptionAsync<RequestArgumentException>(
            () => eventService.Handle(mockCommand, cancellationToken));
            Assert.AreEqual(ex.Message, "Data não pode ser menor que a data atual");

        }

        [TestMethod]
        public async Task QuandoCommandValidoEntaoRetornarEvent()
        {

            //Arrange
            //var command = new Fixture().Create<AddEventCommand>();
            var mockCommand = new AddEventCommand
            {
                Capacity = 10,
                Date = new DateTime(2024, 10, 13),
                Local = "dasdsadsa",
                Name = "dsadsad",
            };

            var eventRepositoryMock = new Mock<IEventRepository>();

            var eventService = new AddEventCommandHandler(eventRepositoryMock.Object);

            var cancellationToken = new CancellationToken();

            //Act
            var lEvent = await eventService.Handle(mockCommand, cancellationToken);

            //Assert
            Assert.AreEqual(mockCommand.Local, lEvent.Local);
            Assert.AreEqual(mockCommand.Name, lEvent.NameEvent);
            Assert.AreEqual(mockCommand.Capacity, lEvent.Capacity);
            Assert.AreEqual(mockCommand.Date, lEvent.Date);;


        }

    }
}
