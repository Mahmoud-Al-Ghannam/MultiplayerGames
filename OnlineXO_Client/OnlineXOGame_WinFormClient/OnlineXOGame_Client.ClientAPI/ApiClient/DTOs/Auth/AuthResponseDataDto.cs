using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.Auth {
    public record AuthResponseDataDto {
        public string AccessToken { get; init; } = string.Empty;
    }
}
