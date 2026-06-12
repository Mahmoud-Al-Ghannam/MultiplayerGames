using OnlineXOGame_Client.ClientAPI.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.Auth;
using OnlineXOGame_Client.WinForms.Common;
using OnlineXOGame_Client.WinForms.Forms.Testing;

namespace OnlineXOGame_Client.WinForms {
    public partial class Form1 : Form {

        private readonly IAuthApiClient _authApiClient;
        private readonly IUserApiClient _userApiClient;
        private readonly IXOGameApiClient _xOGameApiClient;
        private readonly ITokenProvider _tokenProvider;
        private readonly IFormFactory _formFactory;

        private Form1() {
            InitializeComponent();
        }
        public Form1(IAuthApiClient authApiClient,IUserApiClient userApiClient,IXOGameApiClient xOGameApiClient,ITokenProvider tokenProvider,IFormFactory formFactory) : this() {
            _authApiClient = authApiClient;
            _userApiClient = userApiClient;
            _xOGameApiClient = xOGameApiClient;
            _tokenProvider = tokenProvider;
            _formFactory = formFactory;
        }

        private async void button1_Click(object sender,EventArgs e) {
            try {
                var result = await _authApiClient.LoginAsync(new LoginDto { Username = "mahmoud",Password = "1111" },default);
                MessageBox.Show($"Token: {result}");
            }
            catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void button2_Click(object sender,EventArgs e) {
            try {
                var result = await _authApiClient.LoginAsync(new LoginDto { Username = "mahmoud",Password = "11111111" },default);
                MessageBox.Show($"Token: {result}");
            }
            catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void button3_Click(object sender,EventArgs e) {
            try {
                var result = await _userApiClient.GetUsersAsync(default);
                MessageBox.Show($"Token: {result}");
            }
            catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void button4_Click(object sender,EventArgs e) {
            try {
                var result = await _xOGameApiClient.CreateGameAsync(default);
                MessageBox.Show($"Token: {result}");
            }
            catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void button5_Click(object sender,EventArgs e) {
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIwMWt0Y2hxbXgxM2oxNW0yNXozZjAwNXQ0ZyIsInVuaXF1ZV9uYW1lIjoibWFobW91ZCIsIm5iZiI6MTc4MDY5NTU3NCwiZXhwIjoxODEwNjk1NTc0LCJpYXQiOjE3ODA2OTU1NzQsImlzcyI6Ik9ubGluZVhPR2FtZVNlcnZlciIsImF1ZCI6Ik9ubGluZVhPR2FtZUNsaWVudCJ9.5wGlMPStOqf347npD2boi-0Rfeq9VpNwNM83yS91w0k";
            await _tokenProvider.SetAccessTokenAsync(token,default);
            try {
                var result = await _xOGameApiClient.CreateGameAsync(default);
                MessageBox.Show($"Token: {result}");
            }
            catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void button6_Click(object sender,EventArgs e) {
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIwMWt0Y2hxbXgxM2oxNW0yNXozZjAwNXQ0ZyIsInVuaXF1ZV9uYW1lIjoibWFobW91ZCIsIm5iZiI6MTc4MDY5NTU3NCwiZXhwIjoxODEwNjk1NTc0LCJpYXQiOjE3ODA2OTU1NzQsImlzcyI6Ik9ubGluZVhPR2FtZVNlcnZlciIsImF1ZCI6Ik9ubGluZVhPR2FtZUNsaWVudCJ9.5wGlMPStOqf347npD2boi-0Rfeq9VpNwNM83yS91w0k";
            await _tokenProvider.SetAccessTokenAsync(token,default);
            try {
                var result = await _xOGameApiClient.GetGamesAsync(default);
                MessageBox.Show($"Token: {result}");
            }
            catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void button7_Click(object sender,EventArgs e) {
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIwMWt0Y2hxbXgxM2oxNW0yNXozZjAwNXQ0ZyIsInVuaXF1ZV9uYW1lIjoibWFobW91ZCIsIm5iZiI6MTc4MDY5NTU3NCwiZXhwIjoxODEwNjk1NTc0LCJpYXQiOjE3ODA2OTU1NzQsImlzcyI6Ik9ubGluZVhPR2FtZVNlcnZlciIsImF1ZCI6Ik9ubGluZVhPR2FtZUNsaWVudCJ9.5wGlMPStOqf347npD2boi-0Rfeq9VpNwNM83yS91w0k";
            await _tokenProvider.SetAccessTokenAsync(token,default);
            try {
                var result = await _xOGameApiClient.JoinGameAsync("01ktez31g49wxr359pcgt1dnwq",default);
                MessageBox.Show($"Token: {result}");
            }
            catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void button8_Click(object sender,EventArgs e) {
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIwMWt0Y2hxbXgxM2oxNW0yNXozZjAwNXQ0ZyIsInVuaXF1ZV9uYW1lIjoibWFobW91ZCIsIm5iZiI6MTc4MDY5NTU3NCwiZXhwIjoxODEwNjk1NTc0LCJpYXQiOjE3ODA2OTU1NzQsImlzcyI6Ik9ubGluZVhPR2FtZVNlcnZlciIsImF1ZCI6Ik9ubGluZVhPR2FtZUNsaWVudCJ9.5wGlMPStOqf347npD2boi-0Rfeq9VpNwNM83yS91w0k";
            await _tokenProvider.SetAccessTokenAsync(token,default);
            try {
                var result = await _xOGameApiClient.LeaveGameAsync("01ktez31g49wxr359pcgt1dnwq",default);
                MessageBox.Show($"Token: {result}");
            }
            catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void button9_Click(object sender,EventArgs e) {
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIwMWt0Y2hxbXgxM2oxNW0yNXozZjAwNXQ0ZyIsInVuaXF1ZV9uYW1lIjoibWFobW91ZCIsIm5iZiI6MTc4MDY5NTU3NCwiZXhwIjoxODEwNjk1NTc0LCJpYXQiOjE3ODA2OTU1NzQsImlzcyI6Ik9ubGluZVhPR2FtZVNlcnZlciIsImF1ZCI6Ik9ubGluZVhPR2FtZUNsaWVudCJ9.5wGlMPStOqf347npD2boi-0Rfeq9VpNwNM83yS91w0k";
            await _tokenProvider.SetAccessTokenAsync(token,default);
            try {
                var result = await _xOGameApiClient.GetGameAsync("01ktez31g49wxr359pcgt1dnwq",default);
                MessageBox.Show($"Token: {result}");
            }
            catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void button10_Click(object sender,EventArgs e) {
            var form = _formFactory.CreateForm<TestingHubClientForm>();
            this.Hide();
            await form.ShowAsync();
            this.Show();
        }

        private void Form1_Load(object sender,EventArgs e) {
            
        }
    }
}
