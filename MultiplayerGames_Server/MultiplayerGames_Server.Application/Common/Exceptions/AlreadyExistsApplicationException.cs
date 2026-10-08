using System;
using System.Collections.Generic;
using System.Text;

namespace MultiplayerGames_Server.Application.Common.Exceptions
{
    public class AlreadyExistsApplicationException : ApplicationException
    {
        public AlreadyExistsApplicationException(string message)
            : base(message) { }

        public AlreadyExistsApplicationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
