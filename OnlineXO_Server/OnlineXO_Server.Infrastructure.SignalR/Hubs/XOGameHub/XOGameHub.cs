using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using OnlineXO_Server.Application.Abstractions.Services;
using OnlineXO_Server.Application.UseCases.XOGame;
using OnlineXO_Server.Infrastructure.SignalR.Common.Constants;
using OnlineXO_Server.Infrastructure.SignalR.DataModels;
using OnlineXO_Server.Infrastructure.SignalR.Persistence.Data;
using OnlineXO_Server.Infrastructure.SignalR.Services;

namespace OnlineXO_Server.Infrastructure.SignalR.Hubs.XOGameHub;

public class XOGameHub : BaseHub<IXOGameHubClient>
{
    private readonly XOGameService _xOGameService;
    private readonly HubGroupManager _hubGroupManager;
    private readonly ICurrentUserService _currentUserService;

    public XOGameHub(
        XOGameService xOGameService,
        ICurrentUserService currentUserService,
        SignalRDbContext dbContext,
        HubGroupManager hubGroupManager
    )
        : base(currentUserService, dbContext)
    {
        _xOGameService = xOGameService;
        _hubGroupManager = hubGroupManager;
        _currentUserService = currentUserService;
    }

    public async Task JoinLobbyAsync()
    {
        await Groups.AddToGroupAsync(
            Context.ConnectionId,
            HubConstants.XOGameHub.Groups.Lobby,
            default
        );

        string? userId = _currentUserService.GetUserId();
        if (userId == null)
            return;

        await _hubGroupManager.AddUserToGroupAsync(userId, HubConstants.XOGameHub.Groups.Lobby);
    }

    public async Task LeaveLobbyAsync()
    {
        await Groups.RemoveFromGroupAsync(
            Context.ConnectionId,
            HubConstants.XOGameHub.Groups.Lobby,
            default
        );

        string? userId = _currentUserService.GetUserId();
        if (userId == null)
            return;

        await _hubGroupManager.RemoveUserFromGroupAsync(
            userId,
            HubConstants.XOGameHub.Groups.Lobby
        );
    }

    public async Task JoinGameRoomAsync(string gameId)
    {
        await Groups.AddToGroupAsync(
            Context.ConnectionId,
            HubConstants.XOGameHub.Groups.GameRoom(gameId),
            default
        );

        string? userId = _currentUserService.GetUserId();
        if (userId == null)
            return;

        await _hubGroupManager.AddUserToGroupAsync(
            userId,
            HubConstants.XOGameHub.Groups.GameRoom(gameId)
        );
    }

    public async Task LeaveGameRoomAsync(string gameId)
    {
        await Groups.RemoveFromGroupAsync(
            Context.ConnectionId,
            HubConstants.XOGameHub.Groups.GameRoom(gameId),
            default
        );

        string? userId = _currentUserService.GetUserId();
        if (userId == null)
            return;

        await _hubGroupManager.RemoveUserFromGroupAsync(
            userId,
            HubConstants.XOGameHub.Groups.GameRoom(gameId)
        );
    }

    public async Task MakeMoveAsync(string gameId, int row, int col)
    {
        await _xOGameService.MakeMoveAsync(gameId, row, col, default);
    }
}
