using System;
using Microsoft.EntityFrameworkCore;
using OnlineXO_Server.Domain.Aggregates.User;
using OnlineXO_Server.Domain.Aggregates.XOGame;

namespace OnlineXO_Server.Infrastructure.Persistence.Data;

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
}
