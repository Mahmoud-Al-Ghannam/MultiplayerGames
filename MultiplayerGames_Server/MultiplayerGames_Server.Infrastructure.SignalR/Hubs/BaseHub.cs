using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MultiplayerGames_Server.Application.Abstractions.Services;
using MultiplayerGames_Server.Infrastructure.SignalR.Persistence.Data;

namespace MultiplayerGames_Server.Infrastructure.SignalR.Hubs;

public class BaseHub<T> : Hub<T>
    where T : class
{
    private ICurrentUserService _currentUserService;
    private SignalRDbContext _dbContext;

    public BaseHub(ICurrentUserService currentUserService, SignalRDbContext dbContext)
    {
        _currentUserService = currentUserService;
        _dbContext = dbContext;
    }

    public override async Task OnConnectedAsync()
    {
        string? userId = _currentUserService.GetUserId();
        if (userId == null)
            return;

        List<string> allUserGroups = await _dbContext
            .HubGroups.AsNoTracking()
            .Where(g => _dbContext.HubGroupUsers.Any(gu => gu.UserId == userId))
            .Select(g => g.Name)
            .ToListAsync();

        foreach (var group in allUserGroups)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }
    }
}
