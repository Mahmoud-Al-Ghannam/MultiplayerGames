using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.Exceptions {
    public class ApiException : Exception {
        public int StatusCode { get; }

        public ApiException(int statusCode) {
            StatusCode = statusCode;
        }

        public ApiException(string message) : base(message) { }
        public ApiException(string message, int statusCode) : base(message) {
            StatusCode = statusCode;
        }

        public ApiException(string message,Exception innerException) : base(message,innerException) { }
        public ApiException(string message,int statusCode,Exception innerException) : base(message,innerException) {
            StatusCode = statusCode;
        }
    }
}
