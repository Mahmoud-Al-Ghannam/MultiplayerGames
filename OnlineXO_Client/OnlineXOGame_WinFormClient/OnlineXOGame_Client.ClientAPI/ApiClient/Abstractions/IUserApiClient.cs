using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.ApiClient.Abstractions {
    public interface IUserApiClient {
        public Task<BaseResponseDto<IEnumerable<UserInfoDto>>> GetUsersAsync(CancellationToken ct);
        public Task<BaseResponseDto<UserInfoDto>> GetUserByIdAsync(string userId, CancellationToken ct);
        public Task<BaseResponseDto<UserInfoDto>> GetUserByUsernameAsync(string username, CancellationToken ct);

    }
}
