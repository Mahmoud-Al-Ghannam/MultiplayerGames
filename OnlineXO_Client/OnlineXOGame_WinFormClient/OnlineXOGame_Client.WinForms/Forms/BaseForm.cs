using OnlineXOGame_Client.ClientAPI.Abstractions;
using OnlineXOGame_Client.ClientAPI.Exceptions;
using OnlineXOGame_Client.WinForms.Common;
using OnlineXOGame_Client.WinForms.Forms.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OnlineXOGame_Client.WinForms.Forms {
    public partial class BaseForm : Form {
        private readonly ICurrentUserSession _userSession;
        private readonly IFormFactory _formFactory;
        private bool _showToolStrip;
        public BaseForm(ICurrentUserSession userSession,IFormFactory formFactory,bool showToolStrip = true) {
            InitializeComponent();
            _userSession = userSession;
            _formFactory = formFactory;
            _showToolStrip = showToolStrip;
            statusStrip.Visible = false;
        }

        public BaseForm() {
            InitializeComponent();
            statusStrip.Visible = false;
        }

        protected async Task ExecuteAsync(
        Func<Task> asyncAction,
        string loadingMessage = "Processing...",
        string? successMessage = null) {
            try {
                ShowLoading(true,loadingMessage);
                //await Task.Delay(1000); // Ensure UI updates before starting the operation
                await asyncAction();
                if(!string.IsNullOrEmpty(successMessage))
                    MessageBox.Show(successMessage,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(ApiException ex) {
                MessageBox.Show($"Error: {ex.Message}","Request Failed",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            catch(Exception ex) {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally {
                ShowLoading(false);
            }
        }

        private void ShowLoading(bool show,string message = "") {
            if(show) {
                statusStrip.Visible = true;
                lblProgressLabel.Text = message;
            }
            else {
                statusStrip.Visible = false;
            }
        }

        private void BaseForm_Shown(object sender,EventArgs e) {
            toolStrip1.Visible = _showToolStrip;
            tsLblUsername.Text = _userSession?.GetUsername();
        }

        private void tsLblUsername_Click(object sender,EventArgs e) {
            _formFactory.CreateForm<UserProfileForm>().ShowDialog();
        }
    }
}
