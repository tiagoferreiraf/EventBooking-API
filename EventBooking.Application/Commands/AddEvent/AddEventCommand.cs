﻿using EventBooking.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Commands.AddEvent
{
    public class AddEventCommand : IRequest<EventViewModel>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public string Local { get; set; }
    }
}
