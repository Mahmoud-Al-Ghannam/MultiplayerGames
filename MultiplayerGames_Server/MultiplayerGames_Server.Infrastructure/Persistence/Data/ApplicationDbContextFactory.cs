using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiplayerGames_Server.Infrastructure.Common.Constants;

namespace MultiplayerGames_Server.Infrastructure.Persistence.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite(
            $"Data Source=../MultiplayerGames_Server.WebApi/{DbConstants.DefaultDbName}"
        );
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
