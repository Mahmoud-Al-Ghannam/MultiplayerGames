using OnlineXOGame_Client.ClientAPI.Abstractions;
using OnlineXOGame_Client.WinForms.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OnlineXOGame_Client.WinForms.Forms.User {
    public partial class UserProfileForm : BaseForm {

        private readonly ICurrentUserSession _currentUserSession;

        public UserProfileForm(ICurrentUserSession currentUserSession, IFormFactory formFactory) : base(currentUserSession, formFactory,false) {
            InitializeComponent();
            _currentUserSession = currentUserSession;
        }

        public UserProfileForm() {
            InitializeComponent();
        }

        private void UserProfileForm_Shown(object sender,EventArgs e) {
            lblUsername.Text = _currentUserSession.GetUsername();
            lblUserId.Text = _currentUserSession.GetUserId();
        }
    }
}
