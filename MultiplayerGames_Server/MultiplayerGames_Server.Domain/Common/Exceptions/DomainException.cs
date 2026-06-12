using System;

namespace MultiplayerGames_Server.Domain.Common.Exceptions;

public class DomainException : Exception
{
    public string Code => Message;

    public DomainException() { }

    public DomainException(string code)
        : base(code) { }

    public DomainException(string? code, Exception? innerException)
        : base(code, innerException) { }
}
