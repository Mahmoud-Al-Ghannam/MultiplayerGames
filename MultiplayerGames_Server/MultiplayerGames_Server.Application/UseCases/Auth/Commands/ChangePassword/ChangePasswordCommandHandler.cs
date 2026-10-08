using System;
using MediatR;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Abstractions.Services;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Common.Codes;
using UserAgg = MultiplayerGames_Server.Domain.Aggregates.User.User;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.ChangePassword;

public class ChangePasswordCommandHandler
    : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IPasswordHasher _passwordHasher;

    public ChangePasswordCommandHandler(
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUserService,
        IPasswordHasher passwordHasher
    )
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
        _passwordHasher = passwordHasher;
    }

    public async Task<ChangePasswordResponse> Handle(
        ChangePasswordCommand request,
        CancellationToken cancellationToken
    )
    {
        string? userId = _currentUserService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException(AuthCodes.Error.InvalidCredentials);

        UserAgg? user = await _unitOfWork.Users.GetByIdAsync(userId, cancellationToken);
        if (user == null)
            throw new UnauthorizedAccessException(AuthCodes.Error.InvalidCredentials);

        user.ChangePassword(request.OldPassword, request.NewPassword, _passwordHasher);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new ChangePasswordResponse()
        {
            Success = true,
            Message = AuthCodes.Success.PasswordChanged,
        };
    }
}
