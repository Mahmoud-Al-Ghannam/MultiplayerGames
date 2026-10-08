using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiplayerGames_Server.Domain.Aggregates.Otp;
using MultiplayerGames_Server.Domain.Aggregates.User;
using MultiplayerGames_Server.Infrastructure.Persistence.Constants;

namespace MultiplayerGames_Server.Infrastructure.Persistence.Configurations;

internal class OtpConfiguration : IEntityTypeConfiguration<Otp>
{
    public void Configure(EntityTypeBuilder<Otp> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .Property(x => x.CreatedAtUtc)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()")
            .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
