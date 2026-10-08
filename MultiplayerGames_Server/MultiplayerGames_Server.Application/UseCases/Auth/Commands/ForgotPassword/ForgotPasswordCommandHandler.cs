using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Abstractions.Services;
using MultiplayerGames_Server.Application.Common.Exceptions;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Aggregates.Otp;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Constants;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandler
        : IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOtpService _otpService;
        private readonly IOtpCodeHasher _codeHasher;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IEmailService _emailService;
        private readonly IIdGenerator _idGenerator;

        public ForgotPasswordCommandHandler(
            IUnitOfWork unitOfWork,
            IOtpService otpService,
            IOtpCodeHasher codeHasher,
            IEmailTemplateService emailTemplateService,
            IEmailService emailService,
            IIdGenerator idGenerator
        )
        {
            _unitOfWork = unitOfWork;
            _otpService = otpService;
            _codeHasher = codeHasher;
            _emailTemplateService = emailTemplateService;
            _emailService = emailService;
            _idGenerator = idGenerator;
        }

        public async Task<ForgotPasswordResponse> Handle(
            ForgotPasswordCommand request,
            CancellationToken cancellationToken
        )
        {
            var email = request.Email.Trim();

            var user = await _unitOfWork.Users.GetByEmailAsync(email, cancellationToken);
            if (user is null)
                throw new BadRequestApplicationException(AuthCodes.Error.InvalidEmail);

            if (user.EmailConfirmed == false)
                throw new BadRequestApplicationException(AuthCodes.Error.EmailNotVerified);

            var oldOtps = await _unitOfWork.Otps.GetAllUsableOtpsByUserIdAsync(
                user.Id,
                cancellationToken
            );
            foreach (var o in oldOtps)
                if (o.Purpose == OtpPurpose.Password)
                    o.Deactivate();

            // Generate OTP for forgot password
            var otpCode = _otpService.GenerateOtpCode(OtpConstants.CodeLength);
            var otp = Otp.Create(
                user.Id,
                otpCode,
                _codeHasher,
                TimeSpan.FromMinutes(OtpConstants.ExpirationMinutes),
                OtpPurpose.Password,
                _idGenerator
            );

            await _unitOfWork.Otps.AddAsync(otp, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // Send forgot password OTP email using dedicated template
            var emailBody = _emailTemplateService.GenerateResetPasswordTemplate(
                otpCode,
                user.Email.Value,
                OtpConstants.ExpirationMinutes
            );
            await _emailService.SendAsync(
                user.Email.Value,
                "Forgot Password",
                emailBody,
                isHtml: true
            );

            return new ForgotPasswordResponse
            {
                Success = true,
                Message = AuthCodes.Success.ForgotPasswordOtpSent,
            };
        }
    }
}
