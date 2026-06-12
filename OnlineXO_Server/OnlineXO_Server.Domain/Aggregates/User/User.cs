using System;
using System.Diagnostics;
using System.Security.Principal;
using OnlineXO_Server.Domain.Abstractions;
using OnlineXO_Server.Domain.Common;
using OnlineXO_Server.Domain.Common.Codes;
using OnlineXO_Server.Domain.Common.Exceptions;

namespace OnlineXO_Server.Domain.Aggregates.User;

public class User : AggregateRoot
{
    public string Username { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;

    private User() { }

    public static User Create(string username, string password, IIdGenerator idGenerator)
    {
        var user = new User() { Id = idGenerator.NewId() };
        user.SetUsername(username).SetPassword(password);
        return user;
    }

    private User SetUsername(string username)
    {
        username = username?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(username))
            throw new DomainException(UserCodes.Error.Username.Required);

        Username = username;
        return this;
    }

    private User SetPassword(string password)
    {
        password = password?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(password))
            throw new DomainException(UserCodes.Error.Password.Required);

        Password = password;
        return this;
    }

    public User ChangePassword(string oldPassword, string newPassword)
    {
        oldPassword = oldPassword?.Trim() ?? string.Empty;
        if (!string.Equals(Password, oldPassword, StringComparison.Ordinal))
            throw new DomainException(UserCodes.Error.Password.Wrong);

        return SetPassword(newPassword);
    }

    public bool IsPasswordCorrect(string password)
    {
        password = password?.Trim() ?? string.Empty;
        if (string.Equals(Password, password, StringComparison.Ordinal))
            return true;
        return false;
    }
}
