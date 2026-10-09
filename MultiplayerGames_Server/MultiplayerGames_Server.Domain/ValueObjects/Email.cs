using System.Text.RegularExpressions;
using MultiplayerGames_Server.Domain.Common;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Exceptions;

namespace MultiplayerGames_Server.Domain.ValueObjects;

public record class Email : ValueObject
{
    public string Value { get; private init; }

    private Email() { }

    public Email(string value)
    {
        Regex regex = new Regex(ValidationPatterns.Email);
        if (!regex.IsMatch(value))
            throw new DomainException(EmailCodes.Error.InvalidFormat);

        Value = value;
    }
}
