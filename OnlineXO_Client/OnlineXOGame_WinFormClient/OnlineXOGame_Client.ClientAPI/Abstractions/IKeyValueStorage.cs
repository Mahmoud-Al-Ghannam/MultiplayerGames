using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.Abstractions {
    public interface IKeyValueStorage {
        Task SetValueAsync(string key,string value,CancellationToken cancellationToken);
        Task<string?> GetValueAsync(string key,CancellationToken cancellationToken);

        Task RemoveKeyAsync (string key,CancellationToken cancellationToken);
    }
}
