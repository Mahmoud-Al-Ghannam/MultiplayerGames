using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineXO_Server.Domain.Aggregates.User;
using OnlineXO_Server.Domain.Aggregates.XOGame;

namespace OnlineXO_Server.Infrastructure.Persistence.Configurations;

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
