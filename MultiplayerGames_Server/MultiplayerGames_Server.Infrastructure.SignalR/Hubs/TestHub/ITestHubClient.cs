using System;

namespace MultiplayerGames_Server.Infrastructure.SignalR.Hubs.TestHub;

public interface ITestHubClient
{
    Task ValueUpdated(int x);
}
