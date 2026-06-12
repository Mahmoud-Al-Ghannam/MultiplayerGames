using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXO_Server.Application.Common.Exceptions
{
    public class ForbiddenAccessException : ApplicationException
    {
        public ForbiddenAccessException(string message)
            : base(message) { }

        public ForbiddenAccessException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
