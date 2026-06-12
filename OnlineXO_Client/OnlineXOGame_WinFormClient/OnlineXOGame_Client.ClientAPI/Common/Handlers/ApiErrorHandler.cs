using Microsoft.Extensions.Hosting;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs;
using OnlineXOGame_Client.ClientAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace OnlineXOGame_Client.ClientAPI.Common.Handlers {
    internal class ApiErrorHandler : DelegatingHandler {

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken cancellationToken) {
            var response = await base.SendAsync(request,cancellationToken);

            if(!response.IsSuccessStatusCode) {
                await HandleErrorResponse(response,cancellationToken);
            }

            return response;
        }

        private async Task HandleErrorResponse(HttpResponseMessage response,CancellationToken cancellationToken) {
            string? errorBody = null;
            var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);
            BaseResponseDto<object?>? responseDto = null;
            try {
                responseDto = JsonSerializer.Deserialize<BaseResponseDto<object?>>(responseJson);
            }catch { }
            errorBody = responseDto?.Message ?? responseJson;
            throw new ApiException(string.IsNullOrEmpty(errorBody) ? "Some error occurred" : errorBody,(int)response.StatusCode);
        }
    }
}
