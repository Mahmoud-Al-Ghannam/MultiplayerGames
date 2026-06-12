using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.ApiClient.Abstractions {
    public interface IAuthApiClient {
        public Task<BaseResponseDto<AuthResponseDataDto>> LoginAsync(LoginDto request,CancellationToken ct);
        public Task<BaseResponseDto<AuthResponseDataDto>> SignUpAsync(SignUpDto request,CancellationToken ct);
    }
}
