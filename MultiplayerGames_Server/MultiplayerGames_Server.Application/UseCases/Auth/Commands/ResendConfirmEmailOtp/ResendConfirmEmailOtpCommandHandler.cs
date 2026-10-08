using System;
using MediatR;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Abstractions.Services;
using MultiplayerGames_Server.Application.Common.Exceptions;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Aggregates.Otp;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Constants;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ResendConfirmEmailOtp;

public class ResendConfirmEmailOtpCommandHandler
    : IRequestHandler<ResendConfirmEmailOtpCommand, ResendConfirmEmailOtpResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOtpCodeHasher _otpCodeHasher;
    private readonly IIdGenerator _idGenerator;
    private readonly IOtpService _otpService;
    private readonly IEmailService _emailService;
    private readonly IEmailTemplateService _emailTemplateService;

    public ResendConfirmEmailOtpCommandHandler(
        IUnitOfWork unitOfWork,
        IOtpCodeHasher otpCodeHasher,
        IIdGenerator idGenerator,
        IOtpService otpService,
        IEmailService emailService,
        IEmailTemplateService emailTemplateService
    )
    {
        _unitOfWork = unitOfWork;
        _otpCodeHasher = otpCodeHasher;
        _idGenerator = idGenerator;
        _otpService = otpService;
        _emailService = emailService;
        _emailTemplateService = emailTemplateService;
    }

    public async Task<ResendConfirmEmailOtpResponse> Handle(
        ResendConfirmEmailOtpCommand request,
        CancellationToken cancellationToken
    )
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(request.Email, cancellationToken);
        if (user == null)
            throw new BadRequestApplicationException(AuthCodes.Error.InvalidEmail);

        if (user.EmailConfirmed)
            throw new BadRequestApplicationException(AuthCodes.Error.EmailAlreadyConfirmed);

        var otps = await _unitOfWork.Otps.GetAllUsableOtpsByUserIdAsync(user.Id, cancellationToken);
        foreach (var o in otps)
            if (o.Purpose == OtpPurpose.Email)
                o.Deactivate();

        string otpCode = _otpService.GenerateOtpCode(OtpConstants.CodeLength);
        Otp otp = Otp.Create(
            user.Id,
            otpCode,
            _otpCodeHasher,
            TimeSpan.FromMinutes(OtpConstants.ExpirationMinutes),
            OtpPurpose.Email,
            _idGenerator
        );
        await _unitOfWork.Otps.AddAsync(otp, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Send confirm OTP email using dedicated template
        var emailBody = _emailTemplateService.GenerateEmailConfirmationTemplate(
            otpCode,
            user.Email.Value,
            OtpConstants.ExpirationMinutes
        );
        await _emailService.SendAsync(user.Email.Value, "Confirm OTP", emailBody, isHtml: true);

        return new ResendConfirmEmailOtpResponse()
        {
            Success = true,
            Message = AuthCodes.Success.ResentOtpCode,
            Data = null,
        };
    }
}
