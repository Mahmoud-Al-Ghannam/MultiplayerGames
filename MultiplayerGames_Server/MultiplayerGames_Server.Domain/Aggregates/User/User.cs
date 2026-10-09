using System;
using System.Diagnostics;
using System.Security.Principal;
using MultiplayerGames_Server.Domain.Abstractions;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Common;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Exceptions;
using MultiplayerGames_Server.Domain.ValueObjects;

namespace MultiplayerGames_Server.Domain.Aggregates.User;

public class User : AggregateRoot
{
    public string Username { get; private set; } = string.Empty;
    public string HashedPassword { get; private set; } = string.Empty;
    public Email Email { get; private set; } = null!;
    public bool EmailConfirmed { get; private set; } = false;
    public string? ProfileImagePath { get; private set; }

    private User() { }

    public static User Create(
        string username,
        string password,
        Email email,
        string? profileImagePath,
        IPasswordHasher hasher,
        IIdGenerator idGenerator
    )
    {
        var user = new User() { Id = idGenerator.NewId() };
        user.SetUsername(username)
            .ResetPassword(password, hasher)
            .SetEmail(email)
            .SetProfileImagePath(profileImagePath);
        return user;
    }

    public User SetProfileImagePath(string? profileImagePath)
    {
        ProfileImagePath = profileImagePath?.Trim();
        return this;
    }

    public User SetUsername(string username)
    {
        username = username?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(username))
            throw new DomainException(UserCodes.Error.Username.Required);

        Username = username;
        return this;
    }

    public User SetEmail(Email email)
    {
        if (email == null)
            throw new DomainException(UserCodes.Error.Email.Required);

        Email = email;
        return this;
    }

    public User ChangePassword(string oldPassword, string newPassword, IPasswordHasher hasher)
    {
        if (!hasher.Verify(oldPassword, HashedPassword))
            throw new DomainException(AuthCodes.Error.InvalidPassword);

        ResetPassword(newPassword, hasher);
        return this;
    }

    internal User ResetPassword(string password, IPasswordHasher hasher)
    {
        password = password?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(password))
            throw new DomainException(UserCodes.Error.Password.Required);

        HashedPassword = hasher.Hash(password);
        return this;
    }

    internal User ConfirmEmail()
    {
        EmailConfirmed = true;
        return this;
    }

    public void Login(string plainedPassword, IPasswordHasher hasher)
    {
        if (!hasher.Verify(plainedPassword, HashedPassword))
            throw new DomainException(AuthCodes.Error.InvalidEmailOrPassword);

        if (!EmailConfirmed)
            throw new DomainException(AuthCodes.Error.EmailNotVerified);
    }
}
