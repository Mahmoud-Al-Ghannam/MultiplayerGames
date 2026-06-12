using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MultiplayerGames_Server.Application.Common.Exceptions
{
    public class ApplicationAggregateException : ApplicationException
    {
        private readonly ICollection<ApplicationException> _errors = [];

        public ApplicationAggregateException(string message)
            : base(message) { }

        public ApplicationAggregateException(string message, Exception innerException)
            : base(message, innerException) { }

        public ApplicationAggregateException(
            string message,
            ICollection<ApplicationException> errors,
            Exception innerException
        )
            : base(message, innerException)
        {
            foreach (var error in errors)
                _errors.Add(error);
        }

        public IReadOnlyCollection<ApplicationException> Errors => _errors.ToImmutableList();
    }
}
