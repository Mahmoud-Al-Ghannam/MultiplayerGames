using OnlineXOGame_Client.ClientAPI.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.Services {
    internal class CurrentUserSession : ICurrentUserSession {
        private string? _username;
        private string? _userId;
        public string? GetUserId() {
            return _userId;
        }

        public string? GetUsername() {
            return _username;
        }

        public void SetUserSession(string username,string userId) {
            _username = username;
            _userId = userId;
        }
    }
}
