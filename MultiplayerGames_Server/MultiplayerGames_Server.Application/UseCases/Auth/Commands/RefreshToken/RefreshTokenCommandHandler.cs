using MediatR;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Abstractions.Services;
using MultiplayerGames_Server.Application.Common.Exceptions;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Constants;
using RefreshTokenAggregate = MultiplayerGames_Server.Domain.Aggregates.RefreshToken;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenerateTokenService _generateTokenService;
    private readonly IIdGenerator _IdGenerator;
    private readonly IRefreshTokenHasher _refreshTokenHasher;

    public RefreshTokenCommandHandler(
        IUnitOfWork unitOfWork,
        IGenerateTokenService generateTokenService,
        IIdGenerator idGenerator,
        IRefreshTokenHasher refreshTokenHasher
    )
    {
        _unitOfWork = unitOfWork;
        _generateTokenService = generateTokenService;
        _IdGenerator = idGenerator;
        _refreshTokenHasher = refreshTokenHasher;
    }

    public async Task<RefreshTokenResponse> Handle(
        RefreshTokenCommand request,
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

        var newAccessToken = await _generateTokenService.GenerateAccessTokenAsync(
            user,
            cancellationToken
        );
        var newRefreshToken = await _generateTokenService.GenerateRefreshTokenAsync(
            cancellationToken
        );
        RefreshTokenAggregate.RefreshToken newRefreshTokenObject =
            RefreshTokenAggregate.RefreshToken.Create(
                user.Id,
                newRefreshToken,
                TimeSpan.FromMinutes(RefreshTokenConstants.ExpirationMinutes),
                _IdGenerator,
                _refreshTokenHasher
            );
        existsRefreshToken.Replace(newRefreshTokenObject.Id);
        await _unitOfWork.RefreshTokens.AddAsync(newRefreshTokenObject, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new RefreshTokenResponse
        {
            Success = true,
            Message = AuthCodes.Success.RefreshTokenSuccess,
            Data = new RefreshTokenData
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
            },
        };
    }
}
