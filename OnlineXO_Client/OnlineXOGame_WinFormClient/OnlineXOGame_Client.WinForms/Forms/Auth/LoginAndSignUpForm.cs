using OnlineXOGame_Client.ClientAPI.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.Auth;
using OnlineXOGame_Client.WinForms.Common;
using OnlineXOGame_Client.WinForms.Forms.Testing;
using OnlineXOGame_Client.WinForms.Forms.XOGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OnlineXOGame_Client.WinForms.Forms {
    public partial class LoginAndSignUpForm : BaseForm {

        private readonly ITokenProvider _tokenProvider;
        private readonly IAuthApiClient _authApiClient;
        private readonly IUserApiClient _userApiClient;
        private readonly ICurrentUserSession _currentUserSession;
        private readonly IKeyValueStorage _keyValueStorage;
        private readonly SessionManager _sessionManager;

        private string _username = string.Empty;
        private string _password = string.Empty;


        public LoginAndSignUpForm(ITokenProvider tokenProvider,IAuthApiClient authApiClient,IKeyValueStorage keyValueStorage,SessionManager sessionManager,IUserApiClient userApiClient,ICurrentUserSession currentUserSession,IFormFactory formFactory) :
            base(currentUserSession,formFactory,false) {
            InitializeComponent();
            _tokenProvider = tokenProvider;
            _authApiClient = authApiClient;
            _keyValueStorage = keyValueStorage;
            _sessionManager = sessionManager;
            _userApiClient = userApiClient;
            _currentUserSession = currentUserSession;
        }

        private LoginAndSignUpForm() {
            InitializeComponent();
        }


        #region Events

        private async void LoginAndSignUpForm_Shown(object sender,EventArgs e) {
            _username = txtUsername.Text = await _keyValueStorage.GetValueAsync("username",default) ?? string.Empty;
            _password = txtPassword.Text = await _keyValueStorage.GetValueAsync("password",default) ?? string.Empty;
        }

        private async void btnLogin_Click(object sender,EventArgs e) {
            _username = txtUsername.Text;
            _password = txtPassword.Text;

            btnLogin.Enabled = false;
            btnSignUp.Enabled = false;

            await ExecuteAsync(
                async () => {
                    await LoginUseCaseAsync(default);
                },
                "Logging in ..."
            );

            btnLogin.Enabled = true;
            btnSignUp.Enabled = true;
        }

        private async void btnSignUp_Click(object sender,EventArgs e) {
            _username = txtUsername.Text;
            _password = txtPassword.Text;

            btnLogin.Enabled = false;
            btnSignUp.Enabled = false;

            await ExecuteAsync(
                async () => { 
                    await SignUpUseCaseAsync(default); 
                },
                "Signing up ..."
            );

            btnLogin.Enabled = true;
            btnSignUp.Enabled = true;
        }

        private async Task LoginUseCaseAsync(CancellationToken cancellationToken) {
            if(!ValidateForm()) return;
            var response = await _authApiClient.LoginAsync(
                new LoginDto {
                    Username = _username,
                    Password = _password
                },
                cancellationToken
            );
            await StoreCurrentUserSessionInfoUseCaseAsync(_username,response.Data!.AccessToken,cancellationToken);
            await GoToGamesForm();
        }

        #endregion

        private async Task SignUpUseCaseAsync(CancellationToken cancellationToken) {
            if(!ValidateForm()) return;
            var response = await _authApiClient.SignUpAsync(
                new SignUpDto {
                    Username = _username,
                    Password = _password
                },
                cancellationToken
            );
            await StoreCurrentUserSessionInfoUseCaseAsync(_username,response.Data!.AccessToken,cancellationToken);
            await GoToGamesForm();
        }

        private async Task StoreCurrentUserSessionInfoUseCaseAsync(string username, string accessToken,CancellationToken cancellationToken) {
            var userDto = (await _userApiClient.GetUserByUsernameAsync(username,cancellationToken)).Data!;
            _currentUserSession.SetUserSession(userDto.Username,userDto.Id);
            await _tokenProvider.SetAccessTokenAsync(accessToken,cancellationToken);
            await StoreUsernameAndPassword(_username,_password);
        }

        private async Task GoToGamesForm() {

            _sessionManager.StartSession();
            var mainForm = _sessionManager.GetService<GamesForm>();
            Hide();
            await mainForm.ShowAsync();
            Show();
            _sessionManager.EndSession();
        }

        private async Task StoreUsernameAndPassword(string username, string password) {
            await _keyValueStorage.SetValueAsync("username",username,default);
            await _keyValueStorage.SetValueAsync("password",password,default);
        }
        
        private bool ValidateForm () {
            bool res = true;
            if(txtUsername.Text == string.Empty) {
                requiredErrorProvider.SetError(txtUsername,"Username is required");
                res = false;
            }
            else requiredErrorProvider.SetError(txtUsername,null);

            if(txtPassword.Text == string.Empty) {
                requiredErrorProvider.SetError(txtPassword,"Password is required");
                res = false;
            }
            else requiredErrorProvider.SetError(txtPassword,null);

            return res;
        }
    }
}
