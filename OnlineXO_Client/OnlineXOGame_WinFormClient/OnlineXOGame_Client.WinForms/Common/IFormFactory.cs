using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.WinForms.Common {
    public interface IFormFactory {
        T CreateForm<T>() where T : Form;
    }
}
