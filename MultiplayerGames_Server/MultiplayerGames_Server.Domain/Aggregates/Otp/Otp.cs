using System;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Common;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Exceptions;

namespace MultiplayerGames_Server.Domain.Aggregates.Otp;

public class Otp : AggregateRoot
{
    private Otp() { }

    public string UserId { get; private set; }
    public string HashedOtpCode { get; private set; }
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
    public DateTime ExpiredAtUtc { get; private set; }
    public bool IsUsed { get; private set; } = false;
    public OtpPurpose Purpose { get; private set; }
    public bool IsActive { get; private set; } = true;

    public static Otp Create(
        string userId,
        string plainOtpCode,
        IOtpCodeHasher hasher,
        TimeSpan liftTime,
        OtpPurpose purpose,
        IIdGenerator idGenerator
    )
    {
        Otp otp = new Otp();
        otp.Id = idGenerator.NewId();
        otp.SetUserId(userId)
            .SetOtpCode(plainOtpCode, hasher)
            .SetLifeTime(liftTime)
            .SetPurpose(purpose);

        return otp;
    }

    private Otp SetUserId(string userId)
    {
        UserId = userId;
        return this;
    }

    private Otp SetOtpCode(string otpCode, IOtpCodeHasher hasher)
    {
        otpCode = otpCode?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(otpCode))
            throw new DomainException(OtpCodes.Error.Code.Required);
        HashedOtpCode = hasher.Hash(otpCode);
        return this;
    }

    private Otp SetLifeTime(TimeSpan lifeTime)
    {
        if (lifeTime.TotalSeconds < 0)
            throw new DomainException(OtpCodes.Error.LifeTime.Negative);
        ExpiredAtUtc = DateTime.UtcNow.Add(lifeTime);
        return this;
    }

    private Otp SetPurpose(OtpPurpose purpose)
    {
        if (!Enum.IsDefined(typeof(OtpPurpose), purpose))
            throw new DomainException(OtpCodes.Error.Purpose.Invalid);

        Purpose = purpose;
        return this;
    }

    public Otp Deactivate()
    {
        IsActive = false;
        return this;
    }

    public Otp Activate()
    {
        IsActive = true;
        return this;
    }

    public void EnsureVerified()
    {
        if (IsUsed)
            throw new DomainException(OtpCodes.Error.Usage.AlreadyUsed);

        if (!IsActive)
            throw new DomainException(OtpCodes.Error.Activation.NotActive);

        if (DateTime.UtcNow > ExpiredAtUtc)
            throw new DomainException(OtpCodes.Error.LifeTime.Expired);
    }

    public Otp Use()
    {
        IsUsed = true;
        return this;
    }
}
