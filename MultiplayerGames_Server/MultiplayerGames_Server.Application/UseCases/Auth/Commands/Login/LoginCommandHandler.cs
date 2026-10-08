using MediatR;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Abstractions.Services;
using MultiplayerGames_Server.Application.Common.Exceptions;
using MultiplayerGames_Server.Domain.Abstractions;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Constants;
using RefreshTokenAggregate = MultiplayerGames_Server.Domain.Aggregates.RefreshToken;

namespace MultiplayerGames_Server.Application.UseCases.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenerateTokenService _generateTokenService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IRefreshTokenHasher _refreshTokenHasher;
    private readonly IIdGenerator _IdGenerator;

    public LoginCommandHandler(
        IUnitOfWork unitOfWork,
        IGenerateTokenService generateTokenService,
        IPasswordHasher passwordHasher,
        IRefreshTokenHasher refreshTokenHasher,
        IIdGenerator idGenerator
    )
    {
        _unitOfWork = unitOfWork;
        _generateTokenService = generateTokenService;
        _passwordHasher = passwordHasher;
        _refreshTokenHasher = refreshTokenHasher;
        _IdGenerator = idGenerator;
    }

    public async Task<LoginResponse> Handle(
        LoginCommand request,
        CancellationToken cancellationToken
    )
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(request.Email, cancellationToken);
        if (user == null)
            throw new BadRequestApplicationException(AuthCodes.Error.InvalidEmailOrPassword);

        user.Login(request.Password, _passwordHasher);

        string accessToken = await _generateTokenService.GenerateAccessTokenAsync(
            user,
            cancellationToken
        );

        string refreshToken = await _generateTokenService.GenerateRefreshTokenAsync(
            cancellationToken
        );

        RefreshTokenAggregate.RefreshToken refreshTokenObject =
            RefreshTokenAggregate.RefreshToken.Create(
                user.Id,
                refreshToken,
                TimeSpan.FromMinutes(RefreshTokenConstants.ExpirationMinutes),
                _IdGenerator,
                _refreshTokenHasher
            );
        await _unitOfWork.RefreshTokens.AddAsync(refreshTokenObject, cancellationToken);

        var oldRefreshTokens = await _unitOfWork.RefreshTokens.GetAllActiveTokensByUserIdAsync(
            user.Id,
            cancellationToken
        );
        foreach (var oldRefreshToken in oldRefreshTokens)
            oldRefreshToken.Revoke();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        LoginData data = new LoginData() { AccessToken = accessToken, RefreshToken = refreshToken };

        return new LoginResponse
        {
            Success = true,
            Message = AuthCodes.Success.LoginSuccess,
            Data = data,
        };
    }
}
