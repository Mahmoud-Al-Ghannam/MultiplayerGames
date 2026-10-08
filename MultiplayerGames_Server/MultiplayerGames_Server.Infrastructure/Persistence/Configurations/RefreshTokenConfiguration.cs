using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiplayerGames_Server.Domain.Aggregates.RefreshToken;
using MultiplayerGames_Server.Domain.Aggregates.User;

namespace MultiplayerGames_Server.Infrastructure.Persistence.Configurations;

internal class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasQueryFilter(rt => rt.RevokedAtUtc == null && rt.ExpiresAtUtc > DateTime.UtcNow);

        builder
            .Property(x => x.CreatedAtUtc)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()")
            .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
