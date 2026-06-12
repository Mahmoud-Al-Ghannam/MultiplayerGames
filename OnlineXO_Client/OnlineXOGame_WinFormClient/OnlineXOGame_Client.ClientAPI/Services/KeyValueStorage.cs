using OnlineXOGame_Client.ClientAPI.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace OnlineXOGame_Client.ClientAPI.Services {
    internal class KeyValueStorage : IKeyValueStorage {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

        public KeyValueStorage(string filePath = "app_data.json") {
            _filePath = filePath;
        }

        public async Task<string?> GetValueAsync(string key,CancellationToken cancellationToken) {
            if(!File.Exists(_filePath))
                return null;

            await using var stream = File.OpenRead(_filePath);
            var dict = await JsonSerializer.DeserializeAsync<Dictionary<string,string>>(stream,cancellationToken: cancellationToken);
            return dict != null && dict.TryGetValue(key,out var value) ? value : null;
        }

        public async Task RemoveKeyAsync(string key,CancellationToken cancellationToken) {
            if(!File.Exists(_filePath))
                return;

            await using var stream = File.OpenRead(_filePath);
            var dict = await JsonSerializer.DeserializeAsync<Dictionary<string,string>>(stream,cancellationToken: cancellationToken);
            if(dict != null) 
                dict.Remove(key);
        }

        public async Task SetValueAsync(string key,string value,CancellationToken cancellationToken) {
            Dictionary<string,string> dict = new();
            if(File.Exists(_filePath)) {
                await using var readStream = File.OpenRead(_filePath);
                dict = await JsonSerializer.DeserializeAsync<Dictionary<string,string>>(readStream,cancellationToken: cancellationToken)
                       ?? new Dictionary<string,string>();
            }

            dict[key] = value;

            await using var writeStream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(writeStream,dict,_jsonOptions,cancellationToken);
        }
    }
}
