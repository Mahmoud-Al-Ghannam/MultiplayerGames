using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiplayerGames_Server.Infrastructure.SignalR.Common.Constants;

namespace MultiplayerGames_Server.Infrastructure.SignalR.Persistence.Data;

public class SignalRDbContextFactory : IDesignTimeDbContextFactory<SignalRDbContext>
{
    public SignalRDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SignalRDbContext>();
        optionsBuilder.UseSqlite(
            $"Data Source=../MultiplayerGames_Server.WebApi/{DbConstants.DefaultDbName}"
        );
        return new SignalRDbContext(optionsBuilder.Options);
    }
}
