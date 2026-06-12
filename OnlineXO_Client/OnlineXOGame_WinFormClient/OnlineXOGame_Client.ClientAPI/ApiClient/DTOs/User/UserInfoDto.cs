using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.User {
    public record UserInfoDto {
        public string Id { get; init; } = string.Empty;
        public string Username { get; init; } = string.Empty;
    }
}
