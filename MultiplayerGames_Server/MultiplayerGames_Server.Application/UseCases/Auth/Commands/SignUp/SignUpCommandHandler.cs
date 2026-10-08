using MediatR;
using MultiplayerGames_Server.Application.Abstractions;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Abstractions.Services;
using MultiplayerGames_Server.Application.Common;
using MultiplayerGames_Server.Application.Common.Exceptions;
using MultiplayerGames_Server.Domain.Abstractions;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Aggregates.Otp;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Constants;
using MultiplayerGames_Server.Domain.ValueObjects;
using UserAggregate = MultiplayerGames_Server.Domain.Aggregates.User.User;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.SignUp;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand, SignUpResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIdGenerator _idGenerator;
    private readonly IGenerateTokenService _generateTokenService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IFileStorageService _fileStorageService;
    private readonly IOtpService _otpService;
    private readonly IOtpCodeHasher _otpCodeHasher;
    private readonly IEmailService _emailService;
    private readonly IEmailTemplateService _emailTemplateService;

    public SignUpCommandHandler(
        IUnitOfWork unitOfWork,
        IIdGenerator idGenerator,
        IGenerateTokenService generateTokenService,
        IPasswordHasher passwordHasher,
        IFileStorageService fileStorageService,
        IOtpService otpService,
        IOtpCodeHasher otpCodeHasher,
        IEmailService emailService,
        IEmailTemplateService emailTemplateService
    )
    {
        _unitOfWork = unitOfWork;
        _idGenerator = idGenerator;
        _generateTokenService = generateTokenService;
        _passwordHasher = passwordHasher;
        _fileStorageService = fileStorageService;
        _otpService = otpService;
        _otpCodeHasher = otpCodeHasher;
        _emailService = emailService;
        _emailTemplateService = emailTemplateService;
    }

    public async Task<SignUpResponse> Handle(
        SignUpCommand request,
        CancellationToken cancellationToken
    )
    {
        var existingUser = await _unitOfWork.Users.GetByEmailAsync(
            request.Email,
            cancellationToken
        );
        if (existingUser != null)
            throw new BadRequestApplicationException(UserCodes.Error.Email.Duplicate);

        string? profileImagePath = null;
        if (request.ProfileImage != null)
            profileImagePath = await _fileStorageService.SaveFileToRootAsync(
                request.ProfileImage,
                FileRelativePaths.UserProfileImages,
                cancellationToken
            );

        UserAggregate user = UserAggregate.Create(
            request.Username,
            request.Password,
            new Email(request.Email),
            profileImagePath,
            _passwordHasher,
            _idGenerator
        );

        string otpCode = _otpService.GenerateOtpCode(OtpConstants.CodeLength);
        Otp otp = Otp.Create(
            user.Id,
            otpCode,
            _otpCodeHasher,
            TimeSpan.FromMinutes(OtpConstants.ExpirationMinutes),
            OtpPurpose.Email,
            _idGenerator
        );

        await _unitOfWork.Users.AddAsync(user, cancellationToken);
        await _unitOfWork.Otps.AddAsync(otp, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        string emailBody = _emailTemplateService.GenerateEmailConfirmationTemplate(
            otpCode,
            user.Email.Value,
            OtpConstants.ExpirationMinutes
        );

        await _emailService.SendAsync(
            user.Email.Value,
            "Confirm Your Email",
            emailBody,
            true,
            cancellationToken: cancellationToken
        );

        return new SignUpResponse
        {
            Success = true,
            Message = AuthCodes.Success.RegistrationSuccess,
            Data = user.Id,
        };
    }
}
