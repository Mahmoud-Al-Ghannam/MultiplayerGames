using MediatR;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Common.Exceptions;
using MultiplayerGames_Server.Application.UseCases.Auth.Commands.ConfirmEmail;
using MultiplayerGames_Server.Domain.Abstractions.DomainServices;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Common.Codes;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ConfirmEmail;

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, ConfirmEmailResponse>
{
    private readonly IConfirmUserEmailService _confirmUserEmailService;
    private readonly IOtpCodeHasher _otpCodeHasher;
    private readonly IUnitOfWork _unitOfWork;

    public ConfirmEmailCommandHandler(
        IConfirmUserEmailService confirmUserEmailService,
        IUnitOfWork unitOfWork,
        IOtpCodeHasher otpCodeHasher
    )
    {
        _confirmUserEmailService = confirmUserEmailService;
        _unitOfWork = unitOfWork;
        _otpCodeHasher = otpCodeHasher;
    }

    public async Task<ConfirmEmailResponse> Handle(
        ConfirmEmailCommand request,
        CancellationToken cancellationToken
    )
    {
        var email = request.Email.Trim();
        var user = await _unitOfWork.Users.GetByEmailAsync(email, cancellationToken);
        if (user is null)
            throw new BadRequestApplicationException(AuthCodes.Error.InvalidEmailOrOtp);

        if (user.EmailConfirmed)
            throw new BadRequestApplicationException(AuthCodes.Error.EmailAlreadyConfirmed);

        var otpCodeHash = _otpCodeHasher.Hash(request.OtpCode);
        var otp = await _unitOfWork.Otps.GetByCodeHashAndUserIdAsync(
            otpCodeHash,
            user.Id,
            cancellationToken
        );
        if (otp is null)
            throw new BadRequestApplicationException(AuthCodes.Error.InvalidEmailOrOtp);

        _confirmUserEmailService.ConfirmEmail(user, otp);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new ConfirmEmailResponse
        {
            Success = true,
            Message = AuthCodes.Success.EmailConfirmed,
        };
    }
}
