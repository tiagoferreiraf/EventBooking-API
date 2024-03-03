﻿using EventBooking.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Queries.GetAllEvents
{
    public class GetAllEventsQuery : IRequest<List<EventViewModel>>
    {
    }
}
