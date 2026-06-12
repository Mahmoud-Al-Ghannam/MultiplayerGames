using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.Abstractions {
    public interface ICurrentUserSession {
        void SetUserSession(string username,string userId);
        string? GetUsername();
        string? GetUserId();
    }
}
