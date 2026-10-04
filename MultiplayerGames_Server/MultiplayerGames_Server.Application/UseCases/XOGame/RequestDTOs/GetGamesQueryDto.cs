using System;
using MultiplayerGames_Server.Domain.Aggregates.TwoPlayersGame;
using MultiplayerGames_Server.Domain.Aggregates.XOGame;

namespace MultiplayerGames_Server.Application.UseCases.XOGame.RequestDTOs;

public record GetGamesQueryDto
{
    public GameStatus? Status { get; init; }
    public string? WinnerName { get; init; }
}
