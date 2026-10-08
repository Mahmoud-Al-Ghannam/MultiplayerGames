using System;
using MediatR;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Common.Exceptions;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Common.Codes;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.Logout;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRefreshTokenHasher _refreshTokenHasher;

    public LogoutCommandHandler(IUnitOfWork unitOfWork, IRefreshTokenHasher refreshTokenHasher)
    {
        _unitOfWork = unitOfWork;
        _refreshTokenHasher = refreshTokenHasher;
    }

    public async Task<LogoutResponse> Handle(
        LogoutCommand request,
        CancellationToken cancellationToken
    )
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(request.Email.Trim(), cancellationToken);
        if (user is null)
            throw new BadRequestApplicationException(AuthCodes.Error.InvalidEmailOrToken);

        var hashedToken = _refreshTokenHasher.Hash(request.RefreshToken.Trim());
        var existsRefreshToken = await _unitOfWork.RefreshTokens.GetByHashedTokenAndUserIdAsync(
            hashedToken,
            user.Id,
            cancellationToken
        );
        if (existsRefreshToken is null)
            throw new BadRequestApplicationException(AuthCodes.Error.InvalidEmailOrToken);

        existsRefreshToken.Revoke();
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new LogoutResponse
        {
            Success = true,
            Message = AuthCodes.Success.RefreshTokenSuccess,
        };
    }
}
