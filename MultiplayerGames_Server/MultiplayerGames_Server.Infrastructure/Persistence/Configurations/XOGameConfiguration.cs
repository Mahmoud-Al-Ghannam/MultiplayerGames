using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiplayerGames_Server.Domain.Aggregates.User;
using MultiplayerGames_Server.Domain.Aggregates.XOGame;

namespace MultiplayerGames_Server.Infrastructure.Persistence.Configurations;

public class XOGameConfiguration : IEntityTypeConfiguration<XOGame>
{
    public void Configure(EntityTypeBuilder<XOGame> builder)
    {
        builder.HasKey(g => g.Id);

        builder
            .Property(g => g.Board)
            .HasConversion(b => b.ToJsonString(), s => Board.FromJsonString(s));

        builder.HasOne<User>().WithMany().HasForeignKey(g => g.PlayerXId);

        builder.HasOne<User>().WithMany().HasForeignKey(g => g.PlayerOId);
    }
}
