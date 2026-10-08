using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Common.Exceptions;
using MultiplayerGames_Server.Domain.Abstractions.DomainServices;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Aggregates.Otp;
using MultiplayerGames_Server.Domain.Common.Codes;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler
        : IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IOtpCodeHasher _otpCodeHasher;
        private readonly IResetUserPasswordService _resetUserPasswordService;

        public ResetPasswordCommandHandler(
            IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher,
            IOtpCodeHasher otpCodeHasher,
            IResetUserPasswordService resetUserPasswordService
        )
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _otpCodeHasher = otpCodeHasher;
            _resetUserPasswordService = resetUserPasswordService;
        }

        public async Task<ResetPasswordResponse> Handle(
            ResetPasswordCommand request,
            CancellationToken cancellationToken
        )
        {
            var email = request.Email.Trim();
            var user = await _unitOfWork.Users.GetByEmailAsync(email, cancellationToken);
            if (user is null)
                throw new BadRequestApplicationException(AuthCodes.Error.InvalidEmailOrOtp);

            if (user.EmailConfirmed == false)
                throw new BadRequestApplicationException(AuthCodes.Error.EmailNotVerified);

            var otpCodeHash = _otpCodeHasher.Hash(request.OtpCode);
            var otp = await _unitOfWork.Otps.GetByCodeHashAndUserIdAsync(
                otpCodeHash,
                user.Id,
                cancellationToken
            );
            if (otp is null)
                throw new BadRequestApplicationException(AuthCodes.Error.InvalidEmailOrOtp);

            _resetUserPasswordService.ResetPassword(
                user,
                otp,
                request.NewPassword,
                _passwordHasher
            );

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ResetPasswordResponse
            {
                Success = true,
                Message = AuthCodes.Success.PasswordReset,
            };
        }
    }
}
