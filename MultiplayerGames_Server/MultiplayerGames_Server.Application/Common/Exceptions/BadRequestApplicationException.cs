using System;
using System.Collections.Generic;
using System.Text;

namespace MultiplayerGames_Server.Application.Common.Exceptions
{
    public class BadRequestApplicationException : ApplicationException
    {
        public BadRequestApplicationException(string message)
            : base(message) { }

        public BadRequestApplicationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
