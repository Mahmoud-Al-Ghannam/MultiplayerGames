using System;
using Microsoft.EntityFrameworkCore;
using MultiplayerGames_Server.Application.Abstractions.Services;
using MultiplayerGames_Server.Infrastructure.SignalR.DataModels;
using MultiplayerGames_Server.Infrastructure.SignalR.Persistence.Data;

namespace MultiplayerGames_Server.Infrastructure.SignalR.Services;

public class HubGroupManager
{
    private readonly SignalRDbContext _dbContext;
    private readonly ICurrentUserService _currentUserService;

    public HubGroupManager(ICurrentUserService currentUserService, SignalRDbContext dbContext)
    {
        _currentUserService = currentUserService;
        _dbContext = dbContext;
    }

    public async Task AddUserToGroupAsync(string userId, string groupName)
    {
        HubGroup? hubGroup = await _dbContext.HubGroups.FirstOrDefaultAsync(g =>
            g.Name == groupName
        );

        if (hubGroup == null)
        {
            hubGroup = new HubGroup { Name = groupName };
            await _dbContext.HubGroups.AddAsync(hubGroup);
        }
        await _dbContext.SaveChangesAsync();

        if (!_dbContext.HubGroupUsers.Any(gu => gu.UserId == userId && gu.GroupId == hubGroup.Id))
        {
            HubGroupUser groupUser = new HubGroupUser { GroupId = hubGroup.Id, UserId = userId };
            await _dbContext.HubGroupUsers.AddAsync(groupUser);
        }
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveUserFromGroupAsync(string userId, string groupName)
    {
        HubGroupUser? groupUser = await _dbContext.HubGroupUsers.FirstOrDefaultAsync(gu =>
            _dbContext.HubGroups.Any(g => g.Name == groupName && gu.UserId == userId)
        );
        if (groupUser == null)
            return;

        _dbContext.HubGroupUsers.Remove(groupUser);
        await _dbContext.SaveChangesAsync();
    }
}
