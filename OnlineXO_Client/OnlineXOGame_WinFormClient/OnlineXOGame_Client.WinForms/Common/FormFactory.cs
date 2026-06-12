using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.WinForms.Common {
    public class FormFactory : IFormFactory {
        private readonly SessionManager _sessionManager;

        public FormFactory(SessionManager sessionManager) {
            _sessionManager = sessionManager;
        }

        public T CreateForm<T>() where T : Form => _sessionManager.GetService<T>();
    }
}
