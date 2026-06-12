using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiplayerGames_Server.Infrastructure.SignalR.DataModels;

namespace MultiplayerGames_Server.Infrastructure.SignalR.Persistence.Configurations;

public class HubGroupConfiguration : IEntityTypeConfiguration<HubGroup>
{
    public void Configure(EntityTypeBuilder<HubGroup> builder)
    {
        builder.HasKey(g => g.Id);
        builder.HasIndex(g => g.Name);

        builder
            .HasMany<HubGroupUser>()
            .WithOne()
            .HasForeignKey(gu => gu.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
