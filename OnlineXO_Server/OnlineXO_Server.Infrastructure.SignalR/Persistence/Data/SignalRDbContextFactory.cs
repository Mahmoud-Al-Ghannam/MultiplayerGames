using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OnlineXO_Server.Infrastructure.SignalR.Persistence.Data;

public class SignalRDbContextFactory : IDesignTimeDbContextFactory<SignalRDbContext>
{
    public SignalRDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SignalRDbContext>();
        optionsBuilder.UseSqlite("Data Source=../OnlineXOServer.WebApi/xo-game.db");
        return new SignalRDbContext(optionsBuilder.Options);
    }
}
