using OnlineXOGame_Client.ClientAPI.ApiClient.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.ApiClient.ApiClients {
    internal class UserApiClient : BaseApiClient, IUserApiClient {

        public static class Endpoints {
            public static string Controller => "users";
            public static string GetUsers => $"{PrefixApiPath.TrimEnd('/')}/{Controller}";
            public static string GetUserById(string userId) => $"{PrefixApiPath.TrimEnd('/')}/{Controller}/{userId}";
            public static string GetUserByUsername(string username) => $"{PrefixApiPath.TrimEnd('/')}/{Controller}/{username}/by-username";
        }
        public UserApiClient(HttpClient httpClient) : base(httpClient) {
        }

        public Task<BaseResponseDto<IEnumerable<UserInfoDto>>> GetUsersAsync(CancellationToken ct) {
            return GetAsync<BaseResponseDto<IEnumerable<UserInfoDto>>>(Endpoints.GetUsers,ct);
        }

        public async Task<BaseResponseDto<UserInfoDto>> GetUserByIdAsync(string userId,CancellationToken ct) {
            return await GetAsync<BaseResponseDto<UserInfoDto>>(Endpoints.GetUserById(userId),ct);
        }

        public async Task<BaseResponseDto<UserInfoDto>> GetUserByUsernameAsync(string username,CancellationToken ct) {
            return await GetAsync<BaseResponseDto<UserInfoDto>>(Endpoints.GetUserByUsername(username),ct);
        }
    }
}
