using System;
using System.Collections.Generic;
using System.Text;

namespace MultiplayerGames_Server.Application.Common.Exceptions
{
    public class NotFoundApplicationException : ApplicationException
    {
        public NotFoundApplicationException(string message)
            : base(message) { }

        public NotFoundApplicationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
