using System;
using Microsoft.EntityFrameworkCore;
using OnlineXO_Server.Infrastructure.SignalR.DataModels;

namespace OnlineXO_Server.Infrastructure.SignalR.Persistence.Data;

public class SignalRDbContext : DbContext
{
    public SignalRDbContext(DbContextOptions<SignalRDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SignalRDbContext).Assembly);
    }

    public DbSet<HubGroup> HubGroups => Set<HubGroup>();
    public DbSet<HubGroupUser> HubGroupUsers => Set<HubGroupUser>();
}
