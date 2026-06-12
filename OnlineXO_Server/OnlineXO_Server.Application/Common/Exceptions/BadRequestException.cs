using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXO_Server.Application.Common.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message)
            : base(message) { }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
