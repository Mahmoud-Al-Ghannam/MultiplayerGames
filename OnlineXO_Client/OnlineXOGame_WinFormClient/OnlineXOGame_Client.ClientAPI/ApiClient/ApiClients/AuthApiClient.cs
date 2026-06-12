using OnlineXOGame_Client.ClientAPI.ApiClient.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.ApiClient.ApiClients {
    internal class AuthApiClient : BaseApiClient, IAuthApiClient {

        public static class Endpoints {
            public static string Controller => "auth";
            public static string Login => $"{PrefixApiPath.TrimEnd('/')}/{Controller}/login";
            public static string SignUp => $"{PrefixApiPath.TrimEnd('/')}/{Controller}/sign-up";
        }

        public AuthApiClient(HttpClient httpClient) : base(httpClient) {
        }

        public async Task<BaseResponseDto<AuthResponseDataDto>> LoginAsync(LoginDto request,CancellationToken ct) {
            return await PostAsync<LoginDto,BaseResponseDto<AuthResponseDataDto>>(Endpoints.Login,request,ct);
        }

        public async Task<BaseResponseDto<AuthResponseDataDto>> SignUpAsync(SignUpDto request,CancellationToken ct) {
            return await PostAsync<SignUpDto,BaseResponseDto<AuthResponseDataDto>>(Endpoints.SignUp,request,ct);
        }
    }
}
