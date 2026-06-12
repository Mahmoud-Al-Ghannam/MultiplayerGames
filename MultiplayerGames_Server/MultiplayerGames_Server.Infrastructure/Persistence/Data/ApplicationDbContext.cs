using System;
using Microsoft.EntityFrameworkCore;
using MultiplayerGames_Server.Domain.Aggregates.Test;
using MultiplayerGames_Server.Domain.Aggregates.User;
using MultiplayerGames_Server.Domain.Aggregates.XOGame;

namespace MultiplayerGames_Server.Infrastructure.Persistence.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<XOGame> XOGames => Set<XOGame>();
    public DbSet<Test> Tests => Set<Test>();
}
