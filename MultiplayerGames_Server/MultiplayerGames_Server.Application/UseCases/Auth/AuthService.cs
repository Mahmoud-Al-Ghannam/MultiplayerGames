using System;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Abstractions.Services;
using MultiplayerGames_Server.Application.Common.Exceptions;
using MultiplayerGames_Server.Application.UseCases.User.RequestDTOs;
using MultiplayerGames_Server.Application.UseCases.User.ResponseDTOs;
using MultiplayerGames_Server.Domain.Abstractions;
using MultiplayerGames_Server.Domain.Common.Codes;
using UserAggregate = MultiplayerGames_Server.Domain.Aggregates.User.User;

namespace MultiplayerGames_Server.Application.UseCases.User;

public class AuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIdGenerator _idGenerator;
    private readonly IGenerateTokenService _generateTokenService;

    public AuthService(
        IUnitOfWork unitOfWork,
        IGenerateTokenService generateTokenService,
        IIdGenerator idGenerator
    )
    {
        _unitOfWork = unitOfWork;
        _generateTokenService = generateTokenService;
        _idGenerator = idGenerator;
    }

    public async Task<AuthResponseDto> LoginAsync(
        LoginDto request,
        CancellationToken cancellationToken
    )
    {
        var user = await _unitOfWork.Users.GetByUsernameAsync(request.Username, cancellationToken);
        if (user == null || !user.IsPasswordCorrect(request.Password))
            throw new BadRequestException(AuthCodes.Error.InvalidUsernameOrPassword);

        AuthData data = new AuthData()
        {
            AccessToken = await _generateTokenService.GenerateAccessTokenAsync(
                user,
                cancellationToken
            ),
        };

        return new AuthResponseDto
        {
            Success = true,
            Message = AuthCodes.Success.LoginSuccess,
            Data = data,
        };
    }

    public async Task<AuthResponseDto> SignUpAsync(
        SignUpDto request,
        CancellationToken cancellationToken
    )
    {
        var existingUser = await _unitOfWork.Users.GetByUsernameAsync(
            request.Username,
            cancellationToken
        );
        if (existingUser != null)
            throw new BadRequestException(UserCodes.Error.Username.Duplicate);

        UserAggregate user = UserAggregate.Create(request.Username, request.Password, _idGenerator);
        await _unitOfWork.Users.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        AuthData data = new AuthData()
        {
            AccessToken = await _generateTokenService.GenerateAccessTokenAsync(
                user,
                cancellationToken
            ),
        };

        return new AuthResponseDto
        {
            Success = true,
            Message = AuthCodes.Success.RegistrationSuccess,
            Data = data,
        };
    }
}
