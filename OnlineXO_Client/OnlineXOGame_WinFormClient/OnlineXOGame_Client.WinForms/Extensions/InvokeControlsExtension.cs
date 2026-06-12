using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.WinForms.Extensions {
    internal static class InvokeControlsExtension {
        public static void HandledInvoke(this Control control,Action action) {
            if(control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
}
