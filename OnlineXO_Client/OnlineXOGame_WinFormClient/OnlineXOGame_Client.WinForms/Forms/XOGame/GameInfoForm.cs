using OnlineXOGame_Client.ClientAPI.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.XOGame;
using OnlineXOGame_Client.ClientAPI.Common.Enums;
using OnlineXOGame_Client.ClientAPI.Facade;
using OnlineXOGame_Client.ClientAPI.HubClient.DTOs.XOGame;
using OnlineXOGame_Client.WinForms.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OnlineXOGame_Client.WinForms.Forms.XOGame {
    public partial class GameInfoForm : BaseForm {

        private readonly IXOGameFacade _xoGameFacade;
        private readonly ICurrentUserSession _currentUserSession;

        private GameInfoDto? _gameInfo = null;

        public GameInfoForm(IXOGameFacade xoGameFacade,ICurrentUserSession currentUserSession,IFormFactory formFactory) : base(currentUserSession,formFactory) {
            InitializeComponent();
            _xoGameFacade = xoGameFacade;
            _xoGameFacade.GameUpdatedAsync += XOGameFacade_GameUpdatedAsync;
            _currentUserSession = currentUserSession;
        }
        public GameInfoForm() {
            InitializeComponent();
        }


        private void XOGameFacade_GameUpdatedAsync(GameDto dto) {
            LoadGameeInfoFromGameDto(dto);
            LoadGameInfoToControls();
        }

        private void LoadGameeInfoFromGameDto(GameDto dto) {
            _gameInfo = new GameInfoDto {
                Id = dto.Id,
                PlayerX = dto.PlayerX,
                PlayerO = dto.PlayerO,
                Status = dto.Status,
                CurrentTurn = dto.CurrentTurn,
                Winner = dto.Winner,
                CreatedAt = dto.CreatedAt,
                StartedAt = dto.StartedAt,
                EndedAt = dto.EndedAt,
                Board = dto.Board,
                PlayerXId = _gameInfo?.PlayerXId,
                PlayerOId = _gameInfo?.PlayerOId
            };
        }

        public void InitialiseWith(GameInfoDto gameInfo) {
            _gameInfo = gameInfo;
        }

        private void GameInfoForm_Load(object sender,EventArgs e) {
            LoadGameInfoToControls();
        }

        private async void btnCell_Click(object sender,EventArgs e) {
            string tag = ((Button)sender).Tag?.ToString() ?? string.Empty;
            int[] tagValues = tag.Split(',').Select(s => int.Parse(s)).ToArray();
            await ExecuteAsync(
                async () => {
                    await MakeMoveUseCaseAsync(tagValues[0],tagValues[1]);
                },
                loadingMessage: "Making Move..."
            );
        }

        private async Task MakeMoveUseCaseAsync(int row,int col) {
            await _xoGameFacade.MakeMoveAsync(_gameInfo?.Id ?? string.Empty,row,col);
        }

        private void LoadGameInfoToControls() {
            if(_gameInfo == null) return;

            btnCell00.Text = _gameInfo.Board[0][0];
            btnCell01.Text = _gameInfo.Board[0][1];
            btnCell02.Text = _gameInfo.Board[0][2];

            btnCell10.Text = _gameInfo.Board[1][0];
            btnCell11.Text = _gameInfo.Board[1][1];
            btnCell12.Text = _gameInfo.Board[1][2];

            btnCell20.Text = _gameInfo.Board[2][0];
            btnCell21.Text = _gameInfo.Board[2][1];
            btnCell22.Text = _gameInfo.Board[2][2];


            lblGameId.Text = _gameInfo.Id;

            if(_gameInfo.PlayerX == null) {
                lblPlayerX.Text = "[No Player]";
                lblPlayerX.ForeColor = Color.Gray;
            }
            else {
                lblPlayerX.Text = _gameInfo.PlayerX;
                lblPlayerX.ForeColor = Color.Black;
            }
            if(_gameInfo.PlayerO == null) {
                lblPlayerO.Text = "[No Player]";
                lblPlayerO.ForeColor = Color.Gray;
            }
            else {
                lblPlayerO.Text = _gameInfo.PlayerO;
                lblPlayerO.ForeColor = Color.Black;
            }

            lblStatus.Text = _gameInfo.Status;
            lblCurrentTurn.Text = _gameInfo.CurrentTurn;
            lblWinner.Text = (string.IsNullOrEmpty(_gameInfo.Winner)) ? "No Winner" : $"The winner is Player {_gameInfo.Winner}";
            lblCreatedAt.Text = _gameInfo.CreatedAt.ToString("g");
            lblStartedAt.Text = _gameInfo.StartedAt.HasValue ? _gameInfo.StartedAt.Value.ToString("g") : "Not Started";
            lblEndedAt.Text = _gameInfo.EndedAt.HasValue ? _gameInfo.EndedAt.Value.ToString("g") : "Not Ended";




            bool canPlay = (_gameInfo.CurrentTurn == "X" && _gameInfo.PlayerXId == _currentUserSession.GetUserId()) ||
                            (_gameInfo.CurrentTurn == "O" && _gameInfo.PlayerOId == _currentUserSession.GetUserId());

            if(_gameInfo.Status != GameStatus.InProgress.ToString()) {
                canPlay = false;
            }

            bool isNotCurrentPlayerGame = (
                _gameInfo.PlayerXId != _currentUserSession.GetUserId() &&
                _gameInfo.PlayerOId != _currentUserSession.GetUserId()
            );

            btnCell00.Enabled = canPlay;
            btnCell01.Enabled = canPlay;
            btnCell02.Enabled = canPlay;

            btnCell10.Enabled = canPlay;
            btnCell11.Enabled = canPlay;
            btnCell12.Enabled = canPlay;

            btnCell20.Enabled = canPlay;
            btnCell21.Enabled = canPlay;
            btnCell22.Enabled = canPlay;


            if(isNotCurrentPlayerGame) {
                if(_gameInfo.Status == GameStatus.WaitingForPlayers.ToString()) {
                    lblStatus.Text = "Waiting for players to join...";
                }
                else if(_gameInfo.Status != GameStatus.Finished.ToString()) {
                    lblStatus.Text = $"Watching game... Waiting for Player {_gameInfo.CurrentTurn}'s move.";
                }
            }
            else if(canPlay) {
                if(_gameInfo.Status == GameStatus.WaitingForPlayers.ToString()) {
                    lblStatus.Text = "Waiting for opponent to join...";
                }
                else if(_gameInfo.Status != GameStatus.Finished.ToString()) {
                    lblStatus.Text = "It's your turn!";
                }
            }
            else {
                if(_gameInfo.Status == GameStatus.WaitingForPlayers.ToString()) {
                    lblStatus.Text = "Waiting for opponent to join...";
                }
                else if(_gameInfo.Status != GameStatus.Finished.ToString()) {
                    lblStatus.Text = $"Waiting for opponent's move...";
                }
            }
        }

        private void actionsToolStripMenuItem_Click(object sender,EventArgs e) {
            Close();
        }

        private async void GameInfoForm_FormClosing(object sender,FormClosingEventArgs e) {
            await ExecuteAsync(LeaveGameRoomUseCaseAsync,"Leaving Game ...");
        }

        private async Task LeaveGameRoomUseCaseAsync () {
            await _xoGameFacade.LeaveGameRoomAsync(_gameInfo!.Id);
        }
    }
}
