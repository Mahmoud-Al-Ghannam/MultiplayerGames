using System;
using System.Collections.Generic;
using System.Text;

namespace MultiplayerGames_Server.Application.Common.Exceptions
{
    public class AlreadyExistsEntityException : ApplicationException
    {
        public AlreadyExistsEntityException(string message)
            : base(message) { }

        public AlreadyExistsEntityException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
