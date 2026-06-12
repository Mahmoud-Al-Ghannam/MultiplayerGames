using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXO_Server.Application.Common.Exceptions
{
    public class NotFoundEntityException : ApplicationException
    {
        public NotFoundEntityException(string message)
            : base(message) { }

        public NotFoundEntityException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
