using System;
using OnlineXO_Server.Application.Abstractions.Services;
using OnlineXO_Server.Infrastructure.SignalR.Persistence.Data;
using OnlineXO_Server.Infrastructure.SignalR.Services;

namespace OnlineXO_Server.Infrastructure.SignalR.Hubs.TestHub;

public class TestHub : BaseHub<ITestHubClient>
{
    public const string TestGroupName = "test";
    private readonly ICurrentUserService _currentUserService;
    private readonly HubGroupManager _hubGroupManager;

    public TestHub(
        ICurrentUserService currentUserService,
        SignalRDbContext dbContext,
        HubGroupManager hubGroupManager
    )
        : base(currentUserService, dbContext)
    {
        _hubGroupManager = hubGroupManager;
        _currentUserService = currentUserService;
    }

    public async Task Join()
    {
        Console.WriteLine($"Join Called: {Context.ConnectionId} added to '{TestGroupName}' group");
        await Groups.AddToGroupAsync(Context.ConnectionId, TestGroupName);

        string? userId = _currentUserService.GetUserId();
        if (userId == null)
            return;

        await _hubGroupManager.AddUserToGroupAsync(userId, TestGroupName);
    }

    public async Task Leave()
    {
        Console.WriteLine(
            $"Leave Called: {Context.ConnectionId} removed from '{TestGroupName}' group"
        );
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, TestGroupName);

        string? userId = _currentUserService.GetUserId();
        if (userId == null)
            return;

        await _hubGroupManager.RemoveUserFromGroupAsync(userId, TestGroupName);
    }

    public void UpdateValue(int x)
    {
        Console.WriteLine(
            $"UpdateValue Called: Notified all clients in '{TestGroupName}' group with this new value {x}"
        );
        Clients.Group(TestGroupName).ValueUpdated(x);
    }
}
