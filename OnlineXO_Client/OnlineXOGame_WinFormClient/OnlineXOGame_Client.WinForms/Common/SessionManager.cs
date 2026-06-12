using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.WinForms.Common {
    public class SessionManager : IDisposable {
        private readonly IServiceScopeFactory _scopeFactory;
        private IServiceScope? _sessionScope;

        public SessionManager(IServiceScopeFactory scopeFactory) {
            _scopeFactory = scopeFactory;
        }

        public void StartSession() {
            // Create a new scope for the entire session
            _sessionScope = _scopeFactory.CreateScope();
        }

        public T GetService<T>() where T : notnull {
            if(_sessionScope == null)
                throw new InvalidOperationException("Session not started.");
            return _sessionScope.ServiceProvider.GetRequiredService<T>();
        }

        public void EndSession() {
            _sessionScope?.Dispose();
            _sessionScope = null;
        }

        public void Dispose() => EndSession();
    }
}
