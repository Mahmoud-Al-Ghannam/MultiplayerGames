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
        var userDTOs = users
            .Select(u => new UserInfoDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email.Value,
                ProfileImageUrl = u.ProfileImagePath?.ToString(),
            })
            .ToList();

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
            throw new NotFoundApplicationException(UserCodes.Error.NotFound);
        var userDto = new UserInfoDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email.Value,
            ProfileImageUrl = user.ProfileImagePath?.ToString(),
        };

        return new BaseResponse<UserInfoDto?>
        {
            Success = true,
            Message = UserCodes.Success.Retrived,
            Data = userDto,
        };
    }

    public async Task<BaseResponse<UserInfoDto?>> GetUserByEmailAsync(
        string email,
        CancellationToken cancellationToken
    )
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(email, cancellationToken);

        if (user == null)
            throw new NotFoundApplicationException(UserCodes.Error.NotFound);
        var userDto = new UserInfoDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email.Value,
            ProfileImageUrl = user.ProfileImagePath?.ToString(),
        };

        return new BaseResponse<UserInfoDto?>
        {
            Success = true,
            Message = UserCodes.Success.Retrived,
            Data = userDto,
        };
    }
}
