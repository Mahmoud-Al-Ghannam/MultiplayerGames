using OnlineXOGame_Client.ClientAPI.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.XOGame;
using OnlineXOGame_Client.ClientAPI.Common.Enums;
using OnlineXOGame_Client.ClientAPI.Facade;
using OnlineXOGame_Client.WinForms.Common;
using OnlineXOGame_Client.WinForms.Forms.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OnlineXOGame_Client.WinForms.Forms.XOGame {
    public partial class GamesForm : BaseForm {
        private readonly IFormFactory _formFactory;
        private readonly IXOGameFacade _gameFacade;
        private readonly ICurrentUserSession _currentUserSession;

        private GameStatus? _gameStatusFilter = null;
        private string? _winnerFilter = null;

        public GamesForm(IFormFactory formFactory,IXOGameFacade gameFacade,ICurrentUserSession currentUserSession) : base(currentUserSession,formFactory) {
            InitializeComponent();
            _formFactory = formFactory;
            _gameFacade = gameFacade;

            _gameFacade.GameDeletedAsync += _gameFacade_GameDeletedAsync;
            _gameFacade.GameUpdatedAsync += _gameFacade_GameUpdatedAsync;
            _gameFacade.GameCreatedAsync += _gameFacade_GameCreatedAsync;
            _currentUserSession = currentUserSession;
        }

        private GamesForm() {
            InitializeComponent();
        }

        #region Server Event Handlers
        private void _gameFacade_GameCreatedAsync(ClientAPI.HubClient.DTOs.XOGame.GameDto game) {
            AddGameRowToGamesTable(new GameItemDto {
                Id = game.Id,
                PlayerX = game.PlayerX,
                PlayerO = game.PlayerO,
                Status = game.Status,
                CurrentTurn = game.CurrentTurn,
                Winner = game.Winner
            });
        }

        private void _gameFacade_GameUpdatedAsync(ClientAPI.HubClient.DTOs.XOGame.GameDto game) {
            UpdateGameRowInGamesTable(new GameItemDto {
                Id = game.Id,
                PlayerX = game.PlayerX,
                PlayerO = game.PlayerO,
                Status = game.Status,
                CurrentTurn = game.CurrentTurn,
                Winner = game.Winner
            });
        }

        private void _gameFacade_GameDeletedAsync(string gameId) {
            RemoveGameRowFromGamesTable(gameId);
        }

        #endregion


        #region Form Event Handlers
        private async void GamesForm_Shown(object sender,EventArgs e) {
            await ExecuteAsync(
                    async () => {
                        await LoadGamesUseCaseAsync();
                    },"Loading games..."
                );
        }

        private void GamesForm_Load(object sender,EventArgs e) {
            cbGameStatusFilter.SelectedIndex = 0; // Default to "All"
        }

        private void cbGameStatusFilter_SelectedIndexChanged(object sender,EventArgs e) {
            _gameStatusFilter = GetGameStatusFromComboBox((ComboBox)sender);
        }

        private void txtWinnerIdFilter_TextChanged(object sender,EventArgs e) {
            _winnerFilter = txtWinnerFilter.Text.Trim();
            if(string.IsNullOrEmpty(_winnerFilter))
                _winnerFilter = null;
        }

        private async void btnApplyFilter_Click(object sender,EventArgs e) {
            await ExecuteAsync(
                    async () => {
                        await LoadGamesUseCaseAsync();
                    },"Filtering games..."
                );
        }


        private async void dgvGames_CellClick(object sender,DataGridViewCellEventArgs e) {
            // Ignore header clicks (RowIndex == -1)
            if(e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string gameId = dgvGames.Rows[e.RowIndex].Cells["Id"].Value?.ToString() ?? string.Empty;
            string gameStatus = dgvGames.Rows[e.RowIndex].Cells["Status"].Value?.ToString() ?? string.Empty;
            string playerX = dgvGames.Rows[e.RowIndex].Cells["PlayerX"].Value?.ToString() ?? string.Empty;
            string playerO = dgvGames.Rows[e.RowIndex].Cells["PlayerO"].Value?.ToString() ?? string.Empty;
            string currentUser = _currentUserSession.GetUsername() ?? string.Empty;

            if(dgvGames.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                dgvGames.Columns[e.ColumnIndex].Name == "Join") {

                if(
                    !string.IsNullOrEmpty(playerX)
                    && !string.IsNullOrEmpty(playerO)
                    && playerX != currentUser && playerO != currentUser
                ) {
                    MessageBox.Show("Game is already full. You can only watch it.");
                    return;
                }
                else if(gameStatus == GameStatus.Finished.ToString()) {
                    MessageBox.Show("Game is already finished. You can only watch it.");
                    return;
                }

                await ExecuteAsync(
                    async () => {
                        await JoinGameUseCaseAsync(gameId);
                    },"Joining game..."
                );
            }
            else if(dgvGames.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                dgvGames.Columns[e.ColumnIndex].Name == "Watch") {

                await ExecuteAsync(
                    async () => {
                        await WatchGameUseCaseAsync(gameId);
                    },"Joining game..."
                );
            }
        }


        private void dgvGames_RowsAdded(object sender,DataGridViewRowsAddedEventArgs e) {
            lblCountAll.Text = dgvGames.Rows.Count.ToString();
        }

        private void dgvGames_RowsRemoved(object sender,DataGridViewRowsRemovedEventArgs e) {
            lblCountAll.Text = dgvGames.Rows.Count.ToString();
        }

        private async void btnJoin_Click(object sender,EventArgs e) {
            string gameId = txtGameId.Text;
            if(string.IsNullOrEmpty(gameId))
                return;

            await ExecuteAsync(
                    async () => {
                        await JoinGameUseCaseAsync(gameId);
                    },"Joining game..."
                );
        }

        private async void btnWatch_Click(object sender,EventArgs e) {
            string gameId = txtGameId.Text;
            if(string.IsNullOrEmpty(gameId))
                return;

            await ExecuteAsync(
                    async () => {
                        await WatchGameUseCaseAsync(gameId);
                    },"Joining game..."
                );
        }

        private async void btnCreateGame_Click(object sender,EventArgs e) {
            await ExecuteAsync(
                    async () => {
                        await CreateGameUseCaseAsync();
                    },"Creating game..."
                );
        }

        #endregion


        #region Use Cases 
        private async Task JoinGameUseCaseAsync(string gameId) {
            await _gameFacade.JoinGameAsync(gameId,default);
            await WatchGameUseCaseAsync(gameId);
        }

        private async Task WatchGameUseCaseAsync(string gameId) {
            await _gameFacade.JoinGameRoomAsync(gameId);
            BaseResponseDto<GameInfoDto> response = await _gameFacade.GetGameAsync(gameId,default);

            GameInfoForm gameInfoForm = _formFactory.CreateForm<GameInfoForm>();
            gameInfoForm.InitialiseWith(response.Data!);
            Hide();
            await gameInfoForm.ShowAsync();
            Show();
        }

        private async Task LoadGamesUseCaseAsync() {
            var response = await _gameFacade.GetGamesAsync(_gameStatusFilter,_winnerFilter);
            dgvGames.Rows.Clear();

            foreach(var game in response.Data!) {
                AddGameRowToGamesTable(game);
            }

            await _gameFacade.JoinLobbyAsync();
        }


        private async Task CreateGameUseCaseAsync() {
            string gameId = (await _gameFacade.CreateGameAsync(default)).Data!;
            await JoinGameUseCaseAsync(gameId);
        }

        #endregion


        #region Games Table Management
        private void AddGameRowToGamesTable(GameItemDto game) {
            DataGridViewRow row = new DataGridViewRow() {
                Cells = {
                        new DataGridViewTextBoxCell() { Value = game.Id },
                        new DataGridViewTextBoxCell() { Value = game.PlayerX },
                        new DataGridViewTextBoxCell() { Value = game.PlayerO },
                        new DataGridViewTextBoxCell() { Value = game.Status },
                        new DataGridViewTextBoxCell() { Value = game.CurrentTurn },
                        new DataGridViewTextBoxCell() { Value = game.Winner },
                        new DataGridViewButtonCell() { Value = "Join"  },
                        new DataGridViewButtonCell() { Value = "Watch", }
                    }
            };
            dgvGames.Rows.Add(row);
        }

        private void RemoveGameRowFromGamesTable(string gameId) {
            foreach(DataGridViewRow row in dgvGames.Rows) {
                if(row.Cells["Id"].Value?.ToString() == gameId) {
                    dgvGames.Rows.Remove(row);
                    break;
                }
            }
        }

        private void UpdateGameRowInGamesTable(GameItemDto game) {
            foreach(DataGridViewRow row in dgvGames.Rows) {
                if(row.Cells["Id"].Value?.ToString() == game.Id) {
                    row.Cells["PlayerX"].Value = game.PlayerX;
                    row.Cells["PlayerO"].Value = game.PlayerO;
                    row.Cells["Status"].Value = game.Status;
                    row.Cells["CurrentTurn"].Value = game.CurrentTurn;
                    row.Cells["Winner"].Value = game.Winner;
                    break;
                }
            }
        }

        #endregion


        #region Helpers Methods

        private GameStatus? GetGameStatusFromComboBox(ComboBox comboBox) {
            string txt = comboBox.Text.Trim();
            return txt switch {
                "In progress" => GameStatus.InProgress,
                "Waiting for players" => GameStatus.WaitingForPlayers,
                "Finished" => GameStatus.Finished,
                _ => null
            };
        }

        #endregion
    }
}
