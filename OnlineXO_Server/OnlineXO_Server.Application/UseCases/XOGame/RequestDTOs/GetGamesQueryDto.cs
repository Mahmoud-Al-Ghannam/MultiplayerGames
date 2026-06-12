using System;
using OnlineXO_Server.Domain.Aggregates.XOGame;

namespace OnlineXO_Server.Application.UseCases.XOGame.RequestDTOs;

public record GetGamesQueryDto
{
    public GameStatus? Status { get; init; }
    public string? Winner { get; init; }
}
