using Microsoft.Extensions.Logging;
using OnlineXOGame_Client.ClientAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.ApiClient {
    internal abstract class BaseApiClient {
        protected const string PrefixApiPath = "/api/v1";
        protected readonly HttpClient _httpClient;

        protected BaseApiClient(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        protected async Task<TResponse> GetAsync<TResponse>(string url,CancellationToken ct) {
            var response = await _httpClient.GetFromJsonAsync<TResponse>(url,ct);
            EnsureResponseNotNull(response);
            return response!;
        }

        protected async Task<TResponse> PostAsync<TRequest, TResponse>(string url,TRequest request,CancellationToken ct) {
            var response = await _httpClient.PostAsJsonAsync(url,request,ct);
            var res = await response.Content.ReadFromJsonAsync<TResponse>(ct);
            EnsureResponseNotNull(res);
            return res!;
        }

        protected async Task<TResponse> PostAsync<TResponse>(string url,CancellationToken ct) {
            var response = await _httpClient.PostAsync(url,new StringContent(string.Empty),ct);
            response.EnsureSuccessStatusCode();
            var res = await response.Content.ReadFromJsonAsync<TResponse>(ct);
            EnsureResponseNotNull(res);
            return res!;
        }

        protected async Task<TResponse> PutAsync<TRequest, TResponse>(string url,TRequest request,CancellationToken ct) {
            var response = await _httpClient.PutAsJsonAsync(url,request,ct);
            response.EnsureSuccessStatusCode();
            var res = await response.Content.ReadFromJsonAsync<TResponse>(ct);
            EnsureResponseNotNull(res);
            return res!;
        }

        protected async Task<TResponse> PutAsync<TResponse>(string url,CancellationToken ct) {
            var response = await _httpClient.PutAsync(url,null,ct);
            response.EnsureSuccessStatusCode();
            var res = await response.Content.ReadFromJsonAsync<TResponse>(ct);
            EnsureResponseNotNull(res);
            return res!;
        }

        protected async Task<TResponse> DeleteAsync<TResponse>(string url,CancellationToken ct) {
            var res = await _httpClient.DeleteFromJsonAsync<TResponse>(url,cancellationToken: ct);
            EnsureResponseNotNull(res);
            return res!;
        }

        private void EnsureResponseNotNull(object? response) {
            if(response == null)
                throw new ApiException("The data was not fetched, there is some issue. Try again leter, please.",200);
        }
    }
}
