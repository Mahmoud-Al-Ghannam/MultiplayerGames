using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiplayerGames_Server.Domain.Aggregates.User;
using MultiplayerGames_Server.Infrastructure.SignalR.DataModels;

namespace MultiplayerGames_Server.Infrastructure.SignalR.Persistence.Configurations;

public class HubGroupUserConfiguration : IEntityTypeConfiguration<HubGroupUser>
{
    public void Configure(EntityTypeBuilder<HubGroupUser> builder)
    {
        builder.HasKey(g => g.Id);
    }
}
