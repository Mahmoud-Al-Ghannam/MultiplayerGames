using System;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Common.Exceptions;
using MultiplayerGames_Server.Application.Common.Responses;
using MultiplayerGames_Server.Application.UseCases.User.ResponseDTOs;
using MultiplayerGames_Server.Domain.Common.Codes;

namespace MultiplayerGames_Server.Application.UseCases.User;

public class UserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<IEnumerable<UserInfoDto>>> GetUsersAsync(
        CancellationToken cancellationToken
    )
    {
        var users = await _unitOfWork.Users.GetAllAsync(cancellationToken);
        var userDTOs = users.Select(u => new UserInfoDto { Id = u.Id, Username = u.Username });

        return new BaseResponse<IEnumerable<UserInfoDto>>
        {
            Success = true,
            Message = UserCodes.Success.Retrived,
            Data = userDTOs,
        };
    }

    public async Task<BaseResponse<UserInfoDto?>> GetUserByIdAsync(
        string userId,
        CancellationToken cancellationToken
    )
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId, cancellationToken);

        if (user == null)
            throw new NotFoundEntityException(UserCodes.Error.NotFound);
        var userDto = new UserInfoDto { Id = user.Id, Username = user.Username };

        return new BaseResponse<UserInfoDto?>
        {
            Success = true,
            Message = UserCodes.Success.Retrived,
            Data = userDto,
        };
    }

    public async Task<BaseResponse<UserInfoDto?>> GetUserByUsernameAsync(
        string username,
        CancellationToken cancellationToken
    )
    {
        var user = await _unitOfWork.Users.GetByUsernameAsync(username, cancellationToken);

        if (user == null)
            throw new NotFoundEntityException(UserCodes.Error.NotFound);
        var userDto = new UserInfoDto { Id = user.Id, Username = user.Username };

        return new BaseResponse<UserInfoDto?>
        {
            Success = true,
            Message = UserCodes.Success.Retrived,
            Data = userDto,
        };
    }
}
