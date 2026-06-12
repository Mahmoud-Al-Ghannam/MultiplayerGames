using OnlineXOGame_Client.ClientAPI.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.XOGame;
using OnlineXOGame_Client.ClientAPI.Facade;
using OnlineXOGame_Client.ClientAPI.HubClient.Abstractions;
using OnlineXOGame_Client.WinForms.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OnlineXOGame_Client.WinForms.Forms.Testing {
    public partial class TestingHubClientForm : Form {

        private readonly IXOGameFacade _xoGameFacade;
        private readonly ITokenProvider _tokenProvider;

        private string _gameId = string.Empty;
        private TestingHubClientForm() {
            InitializeComponent();
        }

        public TestingHubClientForm(IXOGameFacade xoGameFacade,ITokenProvider tokenProvider) : this() {
            _xoGameFacade = xoGameFacade;
            _tokenProvider = tokenProvider;
            _xoGameFacade.GameUpdatedAsync += XOGameClient_GameUpdatedAsync;
            //_xoGameHubclient.GameUpdatedAsync += XOGameClient_GameUpdatedAsync;
        }

        private void XOGameClient_GameUpdatedAsync(ClientAPI.HubClient.DTOs.XOGame.GameDto gameInfo) {
            btnCell00.Text = gameInfo.Board[0][0];
            btnCell01.Text = gameInfo.Board[0][1];
            btnCell02.Text = gameInfo.Board[0][2];

            btnCell10.Text = gameInfo.Board[1][0];
            btnCell11.Text = gameInfo.Board[1][1];
            btnCell12.Text = gameInfo.Board[1][2];

            btnCell20.Text = gameInfo.Board[2][0];
            btnCell21.Text = gameInfo.Board[2][1];
            btnCell22.Text = gameInfo.Board[2][2];


            lblGameId.Text = gameInfo.Id;
            lblPlayerXId.Text = gameInfo.PlayerX;
            lblPlayerOId.Text = gameInfo.PlayerO;
            lblStatus.Text = gameInfo.Status;
            lblCurrentTurn.Text = gameInfo.CurrentTurn;
        }

        private async void TestingHubClientForm_Load(object sender,EventArgs e) {
        }

        private async void txtGameId_TextChanged(object sender,EventArgs e) {
        }

        private void txtAccessToken_TextChanged(object sender,EventArgs e) {

        }

        private async void button2_Click(object sender,EventArgs e) {
            string gameId = _gameId = txtGameId.Text;
            var response = await _xoGameFacade.GetGameAsync(gameId,default);
            GameInfoDto gameInfo = response!.Data!;

            btnCell00.Text = gameInfo.Board[0][0];
            btnCell01.Text = gameInfo.Board[0][1];
            btnCell02.Text = gameInfo.Board[0][2];

            btnCell10.Text = gameInfo.Board[1][0];
            btnCell11.Text = gameInfo.Board[1][1];
            btnCell12.Text = gameInfo.Board[1][2];

            btnCell20.Text = gameInfo.Board[2][0];
            btnCell21.Text = gameInfo.Board[2][1];
            btnCell22.Text = gameInfo.Board[2][2];


            lblGameId.Text = gameInfo.Id;
            lblPlayerXId.Text = gameInfo.PlayerX;
            lblPlayerOId.Text = gameInfo.PlayerO;
            lblStatus.Text = gameInfo.Status;
            lblCurrentTurn.Text = gameInfo.CurrentTurn;
        }

        private async void button1_Click(object sender,EventArgs e) {
            await _tokenProvider.SetAccessTokenAsync(txtAccessToken.Text,default);
        }

        private async void btnCell_Click(object sender,EventArgs e) {
            string tag = ((Button)sender).Tag?.ToString() ?? string.Empty;
            int[] tagValues = tag.Split(',').Select(s => int.Parse(s)).ToArray();
            await _xoGameFacade.MakeMoveAsync(txtGameId.Text,tagValues[0],tagValues[1]);
        }

        private async void button3_Click(object sender,EventArgs e) {
            await _xoGameFacade.JoinGameRoomAsync(_gameId);
        }
    }
}
