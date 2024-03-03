using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.Exceptions
{
    public class RequestArgumentException : Exception
    {
        public RequestArgumentException(string message) : base(message)
        { }
    }
}
